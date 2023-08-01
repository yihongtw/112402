<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="login.css">
</head>

<body>

    <body>
        <html>

        <body>
 <?php
  require_once('conn.php');
?>
            <div class="system_name">
                <h2>虛擬世界的書架</h2>
            </div>

            <div class="login_page">
                <div id="container1">

                    <div class="login">

                        <h3>登入 Login</h3>

                        <form action='login.php' method='POST'>
                            <input type="text" id="username" name="username" placeholder="帳號" required>
                            <div class="tab"></div>
                            <input type="text" id="password" name="password" placeholder="密碼" required>
                            <div class="tab"></div>
                            <input type="submit" value="登入" class="submit" >
                        </form>

                        <h5 onclick="show_hide()">註冊帳號</h5>

                    </div><!-- login end-->
                </div><!-- container1 end-->
            </div><!-- login_page end-->

            <div class="signup_page" <div id="container2">

                <div class="signup">

                    <h3>註冊 Sign Up</h3>

                    <form action='register.php' method='POST'>
                        <input type="text" id="fullname" name="fullname" placeholder="使用者全名" required>
                        <div class="tab"></div>
                        <input type="text" id="username2" name="username" placeholder="帳號" required>
                        <div class="tab"></div>
                        <input type="text" id="password2" name="password" placeholder="密碼" required>
                        <div class="tab"></div>
                        <input type="text" id="comfirm_password" name="comfirm_password" placeholder="確認密碼" required>
                        <div class="tab"></div>
                        <input type="submit" value="註冊" class="submit">
                    </form>

                    <h5 onclick="show_hide()">登入帳號</h5>

                </div><!-- signup end-->
            </div><!-- container2 end-->
            </div><!-- signup_page end-->
            </div>
            <div class="gohome">
                <a href="首頁.html">回到首頁</a>
            </div>
        </body>

        </html>
    </body>

</html>