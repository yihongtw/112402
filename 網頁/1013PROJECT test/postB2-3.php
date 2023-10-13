<?php
session_start();

require_once("connMysqlboard.php");

// 检查用户是否已登录，如果已登录，则获取用户名
$loggedInUsername = isset($_SESSION['username']) ? $_SESSION['username'] : "";

if (isset($_POST["action"]) && ($_POST["action"] == "add")) {
    $boardsex = $_POST["boardsex"];
    $boardcontent = $_POST["boardcontent"];

    // 插入留言，包括用户名（如果已登录）
    $query_insert = "INSERT INTO board23 (username, boardsex, boardcontent, boardtime) VALUES (?, ?, ?, NOW())";
    $stmt = $db_link->prepare($query_insert);
    $stmt->bind_param("sss", $loggedInUsername, $boardsex, $boardcontent);
    $stmt->execute();
    $stmt->close();
    // 重新导向回到主页面
    header("Location:不動產2-3.php");
}

?>
<html>

<head>
    <title>用戶評論心得</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <link href="commentstyle.css" rel="stylesheet" type="text/css">
    <script language="javascript">
        // 這裡放置 JavaScript 函數，如 checkForm() 等
    </script>
</head>

<body>
    <nav class="home">
        <table> 
            <tr>
                <td>
                    <a class="bd5" href="不動產2-3.php"><img name="board_r1_c5" src="images/瀏覽留言.png" width="110" height="36" ,border="0" alt="瀏覽留言"></a>
                </td>
                <td>
                    <a class="bd7" href="postB2-3.php"><img name="board_r1_c7" src="images/我要留言.png" width="110" height="36" ,border="0" alt="我要留言"></a>
                </td>
            </tr>
        </table>
    </nav>

    <form action="" method="post" name="formPost" id="formPost" onSubmit="return checkForm();">
        <table width="90%" border="0" align="center" cellpadding="4" cellspacing="0">
            <tr valign="top">
                <td class="book" width="80" align="center"><img src="images/book2-3.png" width="200" height="200"><span class="heading"></span></td>
                <td>
                    <!-- <p class="bds">標題 <input type="text" name="boardsubject" id="boardsubject"></p>
                    <p class="bdn">姓名 <input type="text" name="username" id="username"></p> -->
                    <p class="boygirl">性別
                        <input name="boardsex" type="radio" id="radio" value="男" checked>男
                        <input type="radio" name="boardsex" id="radio2" value="女">女
                    </p>
                </td>
                <td>
                    <p><textarea class="comment" name="boardcontent" id="boardcontent"></textarea></p>
                </td>
            </tr>
            <tr valign="top">
                <td colspan="3">
                    <input name="action" type="hidden" id="action" value="add">
                    <input class="btn1" type="submit" name="button" id="button" value="送出留言">
                    <input class="btn2" type="reset" name="button2" id="button2" value="重設資料">
                    <input class="btn3" type="button" name="button3" id="button3" value="回上一頁" onClick="window.history.back();">
                </td>
            </tr>
        </table>
    </form>

    <table align="left" border="0" cellpadding="0" cellspacing="0" width="700">
        <tr>
            <td valign="top" background="images/botbg.jpg" class="trademark">© 2023 ntubimd 112402</td>
        </tr>
    </table>
</body>

</html>