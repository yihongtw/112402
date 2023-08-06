<?php
function GetSQLValueString($theValue, $theType)
{
    switch ($theType) {
        case "string":
            $theValue = ($theValue != "") ? filter_var($theValue, FILTER_SANITIZE_ADD_SLASHES) : "";
            break;
        case "int":
            $theValue = ($theValue != "") ? filter_var($theValue, FILTER_SANITIZE_NUMBER_INT) : "";
            break;
        case "email":
            $theValue = ($theValue != "") ? filter_var($theValue, FILTER_VALIDATE_EMAIL) : "";
            break;
        case "url":
            $theValue = ($theValue != "") ? filter_var($theValue, FILTER_VALIDATE_URL) : "";
            break;
    }
    return $theValue;
}

if (isset($_POST["action"]) && ($_POST["action"] == "add")) {
    require_once("connMysql.php");
    $query_insert = "INSERT INTO board (boardname ,boardsex ,boardsubject ,boardtime ,boardmail ,boardweb ,boardcontent) VALUES (?, ?, ?, NOW(), ?, ?, ?)";
    $stmt = $db_link->prepare($query_insert);
    $stmt->bind_param(
        "ssssss",
        GetSQLValueString($_POST["boardname"], "string"),
        GetSQLValueString($_POST["boardsex"], "string"),
        GetSQLValueString($_POST["boardsubject"], "string"),
        GetSQLValueString($_POST["boardmail"], "email"),
        GetSQLValueString($_POST["boardweb"], "url"),
        GetSQLValueString($_POST["boardcontent"], "string")
    );
    $stmt->execute();
    $stmt->close();
    $db_link->close();
    //重新導向回到主畫面
    header("Location: index.php");
}
?>
<html>

<head>
    <title>用戶評論心得</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <link href="style.css" rel="stylesheet" type="text/css">
    <script language="javascript">
        function checkForm() {
            if (document.formPost.boardsubject.value == "") {
                alert("請填寫標題!");
                document.formPost.boardsubject.focus();
                return false;
            }
            if (document.formPost.boardname.value == "") {
                alert("請填寫姓名!");
                document.formPost.boardname.focus();
                return false;
            }
            if (document.formPost.boardmail.value != "") {
                if (!checkmail(document.formPost.boardmail)) {
                    document.formPost.boardmail.focus();
                    return false;
                }
            }
            if (document.formPost.boardcontent.value == "") {
                alert("請填寫留言內容!");
                document.formPost.boardcontent.focus();
                return false;
            }
            return confirm('確定送出嗎？');
        }
    </script>
</head>

<body>
<nav class="home">
      
      
     
    <tr>
        <td>
    <tr>
        <td><a class="bd5" href="index.php"><img name="board_r1_c5" src="images/瀏覽留言.png" width="110" height="36" ,border="0" alt="瀏覽留言"></a></td>
        <td><a class="bd7" href="post.php"><img name="board_r1_c7" src="images/我要留言.png" width="110" height="36" ,border="0" alt="我要留言"></a></td>
    </tr>
    </table>
    </td>
    </tr>

    <tr>
        <form action="" method="post" name="formPost" id="formPost" onSubmit="return checkForm();">
            <table width="90%" ,border="0" ,align="center" cellpadding="4" cellspacing="0">
                <tr valign="top">
                    <td class="book" width="80" ,align="center"><img src="images/book2.png" alt="我要留言" width="200" height="200"><span class="heading"></span></td>
                    <td>
                        <p class="bds">標題 <input type="text" name="boardsubject" id="boardsubject"></p>
                        <p class="bdn">姓名 <input type="text" name="boardname" id="boardname"></p>
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
                    <input name="action" type="hidden" id="action" value="add">
                    <input class="btn1" type="submit" name="button" id="button" value="送出留言">
                    <input class="btn2" type="reset" name="button2" id="button2" value="重設資料">
                    <input class="btn3" type="button" name="button3" id="button3" value="回上一頁" onClick="window.history.back();">

                </tr>
            </table>
        </form>
        </div>
        </td>
    </tr>
    <tr>
        <td>
            <table ,align="left" ,border="0" cellpadding="0" cellspacing="0" width="700">
                <tr>
                    <td valign="top" background="images/botbg.jpg" class="trademark">© 2023 ntubimd 112402 </td>
                </tr>
            </table>
        </td>
    </tr>
    </table>
    </nav>
</body>

</html>