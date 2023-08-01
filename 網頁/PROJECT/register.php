<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>註冊</title>
</head>
<body>
    <?php
    require_once('conn.php');
    $username = $_POST['username']; // 填入帳號密碼姓名
    $password = $_POST['password'];
    $fullname = $_POST['fullname'];

    $sql = "SELECT `username` FROM `users` WHERE `username`='$username'";
    $result = $conn->query($sql);

    if ($username === '' or $password === '') {
        echo '帳號或密碼沒有填入';
    } else if ($result->num_rows > 0) { // 大於零代表有這個資料，
        echo '這個 username:' . $username . ' 已經註冊過'; {
        }
    } else {
        $sql = "INSERT INTO `users`(`username`, `password`,`fullname`) VALUES ('$username' ,'$password','$fullname')";
        $conn->query($sql); // 這樣寫才會把資料推上去
        echo '你的帳號以成功新增。fullname：' . $fullname;
        echo '<meta http-equiv="refresh" content="2;url=index.php">';
    }

    ?>
</body>

</html>