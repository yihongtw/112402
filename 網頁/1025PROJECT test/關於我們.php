<?php
session_start();
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="author" content="112402組員">
    <meta name="description" content="虛擬世界的書架 提供使用者裡用平台了解投資工具並體驗!">
    <meta name="keywords" content="虛擬世界的書架">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>關於我們</title>
    <!-- 連結CSS外部檔案 -->
    <link rel="stylesheet" href="Newstyle.css">
    <script type="text/javascript" src="logout.js"></script>
</head>

<body>
    <nav>
        <ul class="drop-down-menu">
            <li>
                <a href="首頁.php">　首頁　</a>
            </li>
            <li>
                <a href="關於我們.php">關於我們</a>
            </li>
            <li>
                <a href="園區展示.php">展館園區</a>
            </li>
            <li>
                <a href="回饋問卷.php">問卷調查</a>
            </li>
            <li style="float: right; font-family: Andale Mono, monospace;">
                <?php
                if (isset($_SESSION['username'])) {
                    echo '<div class="dropdown2" onmouseover="showDropdown()" onmouseout="hideDropdown()" id="usernameDropdown">';
                    echo '<a href="#" id="usernameLink">' . $_SESSION['username'] . '</a>';
                    echo '<ul class="dropdown-content2" id="dropdownContent">';
                    echo '<li class="ggli4"><a href="logout.php">Log Out</a></li>';
                    // 可以加入其他下拉選單項目
                    echo '</ul>';
                    echo '</div>';
                } else {
                    echo '<a href="index.php">Log In</a>';
                }
                ?>
            </li>
            <li><a href="#">書籍類別</a>
                <ul class="ggli">
                    <li class="ggli1">
                        <a href="新股票.php">股票書籍</a>
                    </li>
                    <li class="ggli2">
                        <a href="新不動產.php">不動產書籍</a>
                    </li>
                    <li class="ggli3">
                        <a href="新虛擬貨幣.php">虛擬貨幣書籍</a>
                    </li>
                </ul>

            </li>
        </ul>
    </nav>

    <hr class="hr1">
    <section class="h3section">
        <h3>發展理念</h3>
    </section>
    <section class="aboutbg">
        <form class="about" action="" method="post">
            <p>隨著社會的發展，越來越多的大學生希望在經濟上變得更加獨立。他們希望能夠自主管理自己的財務，而不僅僅依賴於父母或其他人的支持，進而更早地接觸到投資理財的概念，並開始學習相關的技巧和策略，隨著互聯網的普及，投資理財相關的資訊變得更加容易獲取但隨之而來也導致資訊過多沒辦法有效分類，我們希望幫助大學生篩選評價較高的書籍讓他們不必再額外花時間去尋找，以往固定式書籍通常是以文字和圖片的形式呈現，主要用於提供知識、故事或資訊，這些書籍的內容是固定的，讀者只能被動地閱讀和消化內容，而互動式書籍則更加多樣化，可以包
                含影片、聲音、動畫、遊戲等多媒體元素，讀者可以通過點擊、滑動、選擇等方式參與其中，讓讀者可以不再透過文字學習。</p>
    </section>
    <section class="h4section">
    <i class="fa fa-book" aria-hidden="true"></i>
        <h4>操作說明</h4>
    </section>
    <section class="aboutbg2">
        
    <div class="video-container">
                <video  width="320" height="240" src="./video/testvideo.mp4" controls></video>
                <video  width="320" height="240" src="./video/testvideo.mp4" controls></video>
                <video  width="320" height="240" src="./video/testvideo.mp4" controls></video>
            </div>
            </section>
            <br>
            <br>
    <footer>
        <p>Copyright © 2023 NTUB IMD 112402. All rights reserved.</p>
    </footer>
</body>

</html>