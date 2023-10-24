<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>註冊</title>
</head>
<body>
    <?php
    require_once('connRegister.php');
    $user = $_POST['user']; // 填入帳號密碼姓名
    $rawPassword = $_POST['password'];//原始密碼
    $confirmPassword = $_POST['confirm_password']; // 確認密碼
    $username = $_POST['username'];

    //使用SHA-256對密碼進行加密
    $hashedPassword = hash('sha256', $rawPassword);

    $sql = "SELECT `user` FROM `registeruser` WHERE `user`='$user'";
    $result = $conn->query($sql);

    if ($user === '' or $rawPassword === '' or $confirmPassword === '') {
        echo '帳號或密碼沒有填入';
    } elseif ($rawPassword !== $confirmPassword) {
        echo '密碼與確認密碼不一致';
    } else if ($result->num_rows > 0) { // 大於零代表有這個資料，
        echo '這個 user:' . $user . ' 已經註冊過';
    } else {
        $sql = "INSERT INTO `registeruser`(`user`, `password`, `username`) VALUES ('$user', '$hashedPassword', '$username')";
        $conn->query($sql); // 這樣寫才會把資料推上去
        echo '你的帳號以成功新增。username：' . $username;
        echo '<meta http-equiv="refresh" content="2;url=index.php">';
    }

    ?>
</body>

</html>