<?php
session_start();
$loggedInUsername = isset($_SESSION['username']) ? $_SESSION['username'] : '';
?>
<?php
require_once("connMysqlboard.php");
//預設每頁筆數
$pageRow_records = 4;
//預設頁數
$num_pages = 1;
//若已經有翻頁，將頁數更新
if (isset($_GET['page'])) {
  $num_pages = $_GET['page'];
}
//本頁開始記錄筆數 = (頁數-1)*每頁記錄筆數
$startRow_records = ($num_pages - 1) * $pageRow_records;
//未加限制顯示筆數的SQL敘述句
$query_RecBoard = "SELECT * FROM board29 ORDER BY boardtime DESC";
//加上限制顯示筆數的SQL敘述句，由本頁開始記錄筆數開始，每頁顯示預設筆數
$query_limit_RecBoard = $query_RecBoard . " LIMIT {$startRow_records}, {$pageRow_records}";
//以加上限制顯示筆數的SQL敘述句查詢資料到 $RecBoard 中
$RecBoard = $db_link->query($query_limit_RecBoard);
//以未加上限制顯示筆數的SQL敘述句查詢資料到 $all_RecBoard 中
$all_RecBoard = $db_link->query($query_RecBoard);
//計算總筆數
$total_records = $all_RecBoard->num_rows;
//計算總頁數=(總筆數/每頁筆數)後無條件進位。
$total_pages = ceil($total_records / $pageRow_records);
?>


<html>

<head>
  <title>心得評論區</title>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
  <link href="commentstyle.css" rel="stylesheet" type="text/css">
</head>

<body style="background-color:	#f5f5dc;">
  <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td>
        <table align="left" border="0" cellpadding="0" cellspacing="0" width="700">
        </table>
      </td>
    </tr>
    <tr>
      <!-- <div class="bdtop"></div> -->
      <td background="images/board_r3_c1.jpg">
        <div id="mainRegion">
          <?php
          session_start(); // 启动会话
          while ($row_RecBoard = $RecBoard->fetch_assoc()) {
            // 查询 registeruser 资料表获取用户信息
            $query_userInfo = "SELECT * FROM registeruser WHERE username = ?";
            $stmt = $db_link->prepare($query_userInfo);
            $stmt->bind_param("s", $row_RecBoard["username"]);
            $stmt->execute();
            $user_info = $stmt->get_result()->fetch_assoc();
            // 获取已登录用户的用户名（假设您将用户名存储在会话中）
            if (isset($_SESSION['username'])) {
              // 用户已登录，获取用户名
              $loggedInUsername = $_SESSION['username'];
            } else {
              // 用户未登录，可以采取适当的操作，如显示登录按钮或者跳转到登录页面
              $loggedInUsername = ''; // 或者留空
            }
          ?>
            <table width="90%" border="0" align="center" cellpadding="2" cellspacing="0">
              <tr valign="top">
                <td width="60" align="center" class="underline">
                  <?php if ($row_RecBoard["boardsex"] == "男") { ?>
                    <img src="images/男.png" alt="我是男生" width="49" height="49">
                  <?php } else { ?>
                    <img src="images/女.png" alt="我是女生" width="49" height="49">
                  <?php } ?>
                  <br>
                  <span class="postname"><?php echo $row_RecBoard["username"]; ?></span>
                </td>
                <td class="underline">
                  <span class="smalltext">[<?php echo $row_RecBoard["boardid"]; ?>]</span>
                  <!-- <span></span> -->
                  <p><?php echo ($row_RecBoard["boardcontent"]); ?></p>
                  <p align="right" class="smalltext">
                    <?php echo $row_RecBoard["boardtime"]; ?>
                  </p>
                </td>
              </tr>
            </table>
          <?php
          }
          ?>
          <div class="btnArea" style="width: 450;">
            <table width="90%" border="0" align="center" cellpadding="4" cellspacing="0">
              <tr>
                <td valign="middle">
                  <p>資料筆數：<?php echo $total_records; ?></p>
                </td>

                <td align="right">
                  <?php if ($num_pages > 1) { // 若不是第一頁則顯示 
                  ?>
                    <a href="?page=1">第一頁</a> | <a href="?page=<?php echo $num_pages - 1; ?>">上一頁</a> |
                  <?php } ?>

                  <?php if ($num_pages < $total_pages) { // 若不是最後一頁則顯示 
                  ?>
                    <a href="?page=<?php echo $num_pages + 1; ?>">下一頁</a> | <a href="?page=<?php echo $total_pages; ?>">最末頁</a>
                  <?php } ?>
                </td>
              </tr>
            </table>
          </div>
        </div>
      </td>
    </tr>
    <tr>
      <!-- <div class="bddown"></div> -->
    </tr>
  </table>
  <div><a class="bdgohome" href="postB2-9.php"><img name="" src="images/我要留言.jpg" width="110" height="36" ,border="0" alt="我要留言"></a></div>
  <div><a class="commentbdgohome" href="首頁.php"><img name="" src="images/回到首頁.jpg" width="110" height="36" ,border="0" alt="回到首頁"></a></div>
</body>

</html>
<?php
$db_link->close();
?>