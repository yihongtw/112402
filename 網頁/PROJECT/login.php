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
    require_once('conn.php'); // 引入這些資料
    $username = $_POST['username'];
    $password = $_POST['password'];
    // 查詢資料庫到底有沒有這些登入的資料
    // 使用 prepared statement 避免 SQL Injection
    $sql = "SELECT * FROM users WHERE username=? AND password=?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("ss", $username, $password);
    $stmt->execute();
    $result = $stmt->get_result();
    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        $_SESSION['fullname'] = $row['fullname'];
        echo '登入成功';
        echo '<meta http-equiv="refresh" content="2;url=首頁.php">';

    } else {
        echo '登入失敗';
    }
    ?>

</body>

</html>