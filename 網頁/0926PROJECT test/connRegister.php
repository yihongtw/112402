<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Document</title>
</head>

<body>
<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "112402";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// 確認是否出現連線錯誤
if (!empty($conn->connect_error)) {
  die('資料庫連線錯誤:' . $conn->connect_error);
}

 // 設定編碼，避免出現亂碼
 $conn->query('SET NAMES UTF8');
 // 設定成臺灣時區
 $conn->query('SET time_zone = "+8:00"');
?>




</body>

</html>