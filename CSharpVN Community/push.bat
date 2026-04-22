@echo off
color 0A
title Trình đẩy lên tự động

echo --------------------------------------------------
echo [1/3] Đang dọn dẹp dữ liệu rác...
:: Xoa cac file tam de Render khong bi loi xung dot
git rm -r --cached . >nul 2>&1

echo [2/3] Đang lưu trữ các thay đổi mới...
git add .
set /p msg="Nhập ghi chú cho bản này (hoặc Enter để bỏ qua): "
if "%msg%"=="" set msg="Update moi nhat vao luc %time%"
git commit -m "%msg%"

echo [3/3] Đang đẩy code lên GitHub và Render...
git push origin master

echo --------------------------------------------------
echo [XONG!] Cho 1-2 phút để Render tự cập nhật.
pause