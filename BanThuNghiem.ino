#include <WiFi.h>
#include <PubSubClient.h>
#include <WiFiClientSecure.h>
#include <ArduinoJson.h>
#include "DHTesp.h"

#define DHTpin 14
DHTesp dht;

#define san1a 27
#define san1b 32
#define san2 26
#define san3 25
#define san4 33
#define sensorPin 12

#define fan_pwm 13  // Chân PWM cho tốc độ quạt
#define TEMP_THRESHOLD_LOW 30
#define TEMP_THRESHOLD_MEDIUM 30.5
#define TEMP_THRESHOLD_HIGH 32

String state_s1 = "off", state_s2 = "off", state_s3 = "off", state_s4 = "off";
String fanstate = "off", manual_state = "off", auto_state = "off";

float t;

const char *ssid = "Mi 11";          // Enter your Wi-Fi name
const char *password = "123789456";  // Enter Wi-Fi password

const char *mqtt_broker = "8ddfcf8afdf04dc98c304d5a6b32fba4.s1.eu.hivemq.cloud";
const char *mqtt_username = "duy123";
const char *mqtt_password = "123456789";
const int mqtt_port = 8883;

bool isAutoMode = true;  // Cờ để xác định chế độ hiện tại (true: auto, false: manual)

WiFiClientSecure espClient;
PubSubClient client(espClient);


bool s1b = false;
unsigned long led2OffTime = 0;
unsigned long timeUpdata_1, timeUpdata_2 = millis();

void setup_wifi() {
  delay(10);
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);
  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  randomSeed(micros());
  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
}

void chotatden() {
  if (s1b == true && millis() >= led2OffTime) {
    digitalWrite(san1b, LOW);
    s1b = false;
    Serial.println("off san 1");
    state_s1 = "off";
  }
}

void callback(char *topic, byte *payload, unsigned int length) {
  String messageTemp;
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");
  for (int i = 0; i < length; i++) {
    messageTemp += (char)payload[i];
  }
  if (!strcmp(topic, "san1")) {
    if (messageTemp == "on1") {
      onsan1();
    } else {
      digitalWrite(san1a, LOW);
      if (digitalRead(sensorPin) == HIGH) {
        s1b = true;
        led2OffTime = millis() + 5000;  // Đặt thời gian tắt LED 2 sau 5 giây
      } else {
        digitalWrite(san1b, LOW);
        Serial.println("off san 1");
        state_s1 = "off";
      }
    }
  }
  else if (!strcmp(topic, "san2")) {
    if (messageTemp == "on2") onsan2();
    else offsan2();
  }
  else if (!strcmp(topic, "san3")) {
    if (messageTemp == "on3") onsan3();
    else offsan3();
  }
  else if (!strcmp(topic, "san4")) {
    if (messageTemp == "on4") onsan4();
    else offsan4();
  }

  if (!strcmp(topic, "mode")) {
    if (messageTemp == "auto") {
      isAutoMode = true;
      auto_state = "on";
      manual_state = "off";
    } else if (messageTemp == "manual") {
      isAutoMode = false;
      auto_state = "off";
      manual_state = "on";
    }
  }

  if (!isAutoMode && !strcmp(topic, "fan")) {
    if (messageTemp == "onfan1") {
      onf1();
    } else if (messageTemp == "onfan2") {
      onf2();
    } else if (messageTemp == "onfan3") {
      onf3();
    } else {
      offf0();
    }
  }
}

void publishMessage(const char *topic, String payload, boolean retained) {
  if (client.publish(topic, payload.c_str(), true))
    Serial.println("Message published [" + String(topic) + "]: " + payload);
}

void reconnect() {
  while (!client.connected()) {
    Serial.print("Attempting MQTT connection...");
    String clientId = "ESP32Client-";
    clientId += String(random(0xffff), HEX);
    if (client.connect(clientId.c_str(), mqtt_username, mqtt_password)) {
      Serial.println("connected");
      client.subscribe("san1");
      client.subscribe("san2");
      client.subscribe("san3");
      client.subscribe("san4");
      client.subscribe("mode");
      client.subscribe("fan");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      delay(5000);
    }
  }
}

void offf0() {
  ledcWrite(0, 0);  // 0% duty cycle
  fanstate = "off";
}

void onf1() {
  ledcWrite(0, 200);  // 25% duty cycle
  fanstate = "on1";
}

void onf2() {
  ledcWrite(0, 220);  // 50% duty cycle
  fanstate = "on2";
}

void onf3() {
  ledcWrite(0, 255);  // 100% duty cycle
  fanstate = "on3";
}

void onsan1() {
  digitalWrite(san1a, HIGH);
  digitalWrite(san1b, HIGH);
  Serial.println("on san 1");
  state_s1 = "on";
}

void offsan2() {
  digitalWrite(san2, LOW);
  Serial.println("off san 2");
  state_s2 = "off";
}

void onsan2() {
  digitalWrite(san2, HIGH);
  Serial.println("on san 2");
  state_s2 = "on";
}

void offsan3() {
  digitalWrite(san3, LOW);
  Serial.println("off san 3");
  state_s3 = "off";
}

void onsan3() {
  digitalWrite(san3, HIGH);
  Serial.println("on san 3");
  state_s3 = "on";
}

void offsan4() {
  digitalWrite(san4, LOW);
  Serial.println("off san 4");
  state_s4 = "off";
}

void onsan4() {
  digitalWrite(san4, HIGH);
  Serial.println("on san 4");
  state_s4 = "on";
}

void send_data() {
  t = dht.getTemperature();
  String tempStr = String(t, 1) + "°C";
  publishMessage("nhietdo", tempStr, true);
  timeUpdata_1 = millis();
}


void autofan() {
  if (isAutoMode) {  // Trong chế độ auto, điều khiển quạt dựa trên ngưỡng nhiệt độ
    manual_state = "off";
    auto_state = "on";
    float x;
    x = t - 32;
    if (t <= 32) {
      ledcWrite(0, 0);
    } else if (t < 35) {
      float x = t - 32;
      ledcWrite(0, 200 + (55 / 3) * x); // Tăng dần PWM từ 200 đến 255 khi nhiệt độ từ 32 đến dưới 35
    } else {
      ledcWrite(0, 255); // Đặt PWM tối đa nếu nhiệt độ >= 35
    }
  }
}

void send_state() {
  DynamicJsonDocument doc(256);
  doc["modeauto"] = auto_state;
  doc["modemanual"] = manual_state;
  doc["San1"] = state_s1;
  doc["San2"] = state_s2;
  doc["San3"] = state_s3;
  doc["San4"] = state_s4;

  // Chỉ thêm trạng thái quạt khi ở chế độ thủ công
  if (isAutoMode) {
    doc["fan"] = "NO";
  } else {
    doc["fan"] = fanstate;
  }

  char state[256];
  serializeJson(doc, state);
  client.publish("court_state", state, true);
}
void setup() {
    pinMode(san1a, OUTPUT);
    pinMode(san1b, OUTPUT);
    pinMode(san2, OUTPUT);
    pinMode(san3, OUTPUT);
    pinMode(san4, OUTPUT);
    pinMode(DHTpin, INPUT);
    pinMode(sensorPin, INPUT);
    pinMode(fan_pwm, OUTPUT);
    ledcSetup(0, 5000, 8);      // 5kHz PWM frequency, 8-bit resolution
    ledcAttachPin(fan_pwm, 0);  // Gắn chân PWM với kênh PWM đã cài đặt
    //digitalWrite(san1, HIGH);
    //digitalWrite(san2, HIGH);
    //digitalWrite(san3, HIGH);
    //digitalWrite(san4, HIGH);
    //espClient.setInsecure();
    espClient.setInsecure();
    dht.setup(DHTpin, DHTesp::DHT22);
    Serial.begin(115200);
    setup_wifi();
    client.setServer(mqtt_broker, mqtt_port);
    client.setCallback(callback);
  }

  void loop() {
    if (!client.connected()) {
      reconnect();
    }
    client.loop();
    chotatden();
    if (millis() - timeUpdata_1 > 2000) {
      send_data();
      //send_state();
    }
    if (millis() - timeUpdata_2 > 2000) {
      //send_data();
      send_state();
    }
    autofan();
  }
