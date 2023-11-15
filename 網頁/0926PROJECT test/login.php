<?php
session_start();
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>登入</title>
    
</head>

<body>

    <?php
    require_once('connRegister.php'); // 引入這些資料
    $user = $_POST['user'];
    $password = $_POST['password'];

    // 查詢資料庫到底有沒有這些登入的資料
    // 使用 prepared statement 避免 SQL Injection
    $sql = "SELECT * FROM registeruser WHERE user=? AND password=?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("ss", $user, $password);
    $stmt->execute();
    $result = $stmt->get_result();
    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        $_SESSION['username'] = $row['username'];

        // 在這裡加入 JavaScript 代碼，彈出登入成功的提示框
        echo '<script>';
        echo 'alert("登入成功");';
        echo 'window.location.href = "首頁.php";'; // 重定向到首頁
        echo '</script>';
    } else {
        echo '登入失敗';
    }
    ?>

</body>

</html>
