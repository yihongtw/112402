<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="login.css">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@300&display=swap" rel="stylesheet">
    <!-- 內文 -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <!-- 標題 -->
    <link href="https://fonts.googleapis.com/css2?family=Bowlby+One+SC&display=swap" rel="stylesheet">
    <script type="text/javascript" src="login.js"></script>
</head>

<body>
    <?php
    require_once('connRegister.php');
    ?>
    <nav>
        <div class="LOGO">
            <img src="images/LOGO.png" alt="">
        </div>
        <ul>
            <i class="fa fa-sign-in" aria-hidden="true"></i>
            <li class="signup"><button onclick="location.href='index.php'">Sign Up</button></li>
        </ul>
    </nav>
    <h1>Create Account</h1>

    <form action='register.php' method='POST' class="form2">
        <div>
        <label for="userName">
        <i class="fa fa-id-badge" aria-hidden="true"></i>
                YOUR USERNAME
            </label><br />
        <input type="text" id="username1" name="username" placeholder="使用者全名" required>
</div>
    <div>
        <label for="useraccount">
        <i class="fa fa-user-circle-o" aria-hidden="true"></i>
                YOUR ACCOUNT
            </label><br />
            <input type="text" id="username2" name="user" placeholder="帳號" required>
    </div>
    <div>
        <label for="password">
        <i class="fa fa-sign-in" aria-hidden="true"></i>
                PASSWORD
            </label><br />
            <input type="password" id="password2" name="password" placeholder="密碼" required>
    </div>
    <div>
        <label for="confirm_password">
        <i class="fa fa-sign-in" aria-hidden="true"></i>
                PASSWORD
            </label><br />
            <input type="password" id="confirm_password" name="confirm_password" placeholder="確認密碼" required>
    </div>
        <input type="submit" value="註冊" class="submit">
    </form>

    <footer>
        <p>Copyright © 2023 NTUB IMD 112402. All rights reserved.</p>
    </footer>
</body>

</html>