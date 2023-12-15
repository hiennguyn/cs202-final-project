# 2059014_FinalProject 
Giới thiệu: Đây là ứng dụng thi và soạn đề trắc nghiệm nhầm kiếm tra kiến thức của một công ty công nghệ thông tin được thực hiện bằng ngôn ngữ C#. Ứng dụng là đồ án cuối kỳ môn Advanced-Object Oriented Programming. 

Chương trình bao gồm:  
1. Module Soạn đề  
* Soạn câu hỏi  
* Tạo đề thi  
* Chấm bài  
2. Module Thi trắc nghiệm


### Thông tin liên lạc  
* Tên: Nguyễn Phúc Hiên  
* ID: 2059014
* Lớp: 2oBIT1
* Email: 2059014@itec.hcmus.edu.vn

### Mã nguồn project  
[Github](https://github.com/hiennguyn/2059014_FinalProject)  

### Các chức năng cơ bản của chương trình  
1. Soạn câu hỏi 
* Thêm, sửa, xóa câu hỏi trong ngân hàng câu hỏi. Các câu hỏi sau khi tạo sẽ được được lưu theo chủ đề dưới định dạng file XML  
2. Tạo đề thi
* Đề thi được tạo ngẫu nhiên theo số lượng câu hỏi yêu cầu hoặc theo chủ đề nhất định. Đề thi sau khi tạo sẽ được lưu dưới 2 file: 1 file có đáp án và 1 file không đáp án để được chuyển tới các thi sinh thamgia kì thi  
* Ngoài ra, ứng dụng cho phép xây dựng đề tự chọn dựa trên ngân hàng câu hỏi   
3. Thi trắc nghiệm
* Thí sinh sau khi nhận đề dưới dạng file xml sẽ tải lên để thi trắc nghiệm. Chương trình hỗ trợ di chuyển tới lui giữa các câu hỏi và có bảng tình trạng câu hỏi biểu thị bằng màu sắc để thí sinh lưu ý các câu đã làm, chưa làm và cần xem lại  
* Ứng dụng bao gồm đồng hồ đếm ngược thời gian làm bài căn cứ theo số lượng câu hỏi (15s/1 câu) và sẽ tự động lưu file đáp án dưới địng dạng xml khi hết giờ làm bài
![Module Thi]([images/image.jpg](https://drive.google.com/file/d/1-_7Xp7RPHlErQoiPK9ur9mpKhR5uFyY3/view?usp=drive_link))

4. Chấm bài  
* Các file đáp án của thí sinh sẽ được bỏ trong một thư mục và tải lên để tính điểm. Thông tin thí sinh,mã đề, ngày giờ nộp bài, số lượng câu đúng, điểm được qui đổi trên thang 10 sẽ được lưu dưới dạng file txt và sắp xếp theo thứ tự điểm giảm dần  

### Các chức năng nâng cao
* Ứng dụng soạn đề yêu cầu đăng nhập trước khi sử dụng giúp tăng tính bảo mật cho người ra đề
* Hỗ trợ thanh tìm kiếm giúp người dùng tìm kiếm câu hỏi trong ngân hàng câu hỏi hoặc theo chủ đề
* Bảng tình trạng câu hỏi được thể hiện bằng màu sắc giúp thí sinh dễ nhận biết tình trạng các câu hỏi trong thời gian kiểm tra  

### Đánh giá mức độ hoàn thành bài tập  
Chương trình được xây dựng đáp ứng các nhu cầu cơ bản của người sử dụng. Tuy nhiên, chương trình vẫn còn một số lỗi và các chức năng nâng cao còn khá ít.  

### Nguồn tham khảo
* Bài làm có tham khảo dựa trên các tài liệu hướng dẫn của thầy Nguyễn Đức Huy
* [Reference](https://docs.microsoft.com/vi-vn/dotnet/desktop/winforms/controls/enable-drag-and-drop-operations-with-wf-richtextbox-control?view=netframeworkdesktop-4.8)



