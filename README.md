# CHƯƠNG TRÌNH QUẢN LÝ SÂN CẦU LÔNG THÔNG MINH

## Giới thiệu
Chương trình quản lý sân cầu lông thông minh với các chức năng tự động bật tắt đèn theo giờ, cảm biến nhiệt độ và bật quạt nhằm tiết kiệm điện năng và chi phí quản lý. Chương trình được phát triển với công nghệ WinForm .NET trên nền tảng .NET 6.0.

## Các bước cài đặt và chạy chương trình

### 1. Cài đặt chương trình (không có phần cứng và Arduino)
Các bước này nhằm kiểm tra chương trình có hoạt động tốt hay không.

**Bước 1: Tải file code**  
Tải file code của chương trình về máy.

**Bước 2: Thêm vào Visual Studio Code**  
Mở Visual Studio Code và thêm dự án vào.

**Bước 3: Tạo tài khoản Cloud Client MQTT**  
Truy cập trang web [HiveMQ](https://www.hivemq.com/) và tạo một tài khoản miễn phí.

**Bước 4: Tạo một Client miễn phí**  
Tạo một Client miễn phí trên HiveMQ.

**Bước 5: Đăng ký các topic**  
Đăng ký các topic: `san1`, `san2`, `san3`, `san4`, `fan`.

**Bước 6: Điền thông tin kết nối**  
Mở form `Form1` và form `DatSan`, điền các thông tin cần thiết ở phần connect.

**Bước 7: Tạo tài khoản SMPT để gửi email**  
1. Đăng nhập vào tài khoản Gmail (phải có bảo mật 2 lớp).  
2. Tạo một tài khoản ứng dụng trong Gmail.

**Bước 8: Nhập mật khẩu ứng dụng**  
Lấy mật khẩu do Google cấp và điền vào phần mật khẩu trong chương trình, nhập tên tài khoản Gmail của bạn.

**Bước 9: Chạy chương trình**  
Chạy chương trình và kiểm tra các chức năng.

### 2. Cài đặt chương trình (có phần cứng và Arduino)
Có thể đọc các topic có trong file Arduino và đăng ký các topic tương tự.

**Bước 1: Cài đặt Arduino**  
Cài đặt phần mềm Arduino IDE trên máy tính của bạn.

**Bước 2: Tải file Arduino**  
Tải file code Arduino về máy.

**Bước 3: Nhập tên và mật khẩu WiFi**  
Mở file code Arduino, nhập tên và mật khẩu WiFi của bạn.

**Bước 4: Tải lên Arduino**  
Kết nối Arduino với máy tính và tải lại code lên Arduino.

**Bước 5: Làm theo các bước cài đặt không có phần cứng**  
Thực hiện các bước từ (1) đến (9) như đã hướng dẫn ở phần trên và chuẩn bị các phần cứng sau:
- **Module ESP32**: Đảm nhiệm vai trò xử lý và kết nối mạng.
- **Cảm biến DHT22**: Đo nhiệt độ và độ ẩm.
- **Module Relay**: Điều khiển bật tắt các thiết bị điện.
- **MOSFET REP50N6**: Đóng vai trò chuyển mạch công suất cao.
- **Cảm biến LD2410C**: Phát hiện chuyển động.
- **Mạch giảm áp XL4015**: Giảm áp từ nguồn 12V xuống mức điện áp cần thiết cho các thiết bị.
- **Adapter 12V-5A**: Cung cấp nguồn điện cho hệ thống.

## Lưu ý
Chương trình chú trọng vào phần cứng nên sẽ có ít các chức năng ngoài lề, chủ yếu tập trung vào các chức năng đặt sân và quản lý thiết bị.

Chúc các bạn cài đặt và sử dụng chương trình thành công!
