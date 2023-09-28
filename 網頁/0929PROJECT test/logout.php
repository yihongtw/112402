<?php
session_start();
// 清除用戶相關的會話數據，包括用戶名

unset($_SESSION['username']);

// 顯示登出成功消息
echo '<script>';
echo 'alert("登出成功");';
echo 'window.location.href = "first首頁.php";'; // 重定向到首頁
echo '</script>';
?>
