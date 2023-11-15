<?php
session_start();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>虛擬貨幣</title>
    <link rel="stylesheet" href="Newstyle.css">
</head>
<body>
<nav>
        <ul>
            <!-- <li class=logop> <a href=""><img src="/images/LOGOP.jpg" alt=""></a> </li>
            </li> -->
            <a href=""><img class="logop" src="images/LOGOP3.jpg"></a>
            <li>
                <a href="首頁.php">首頁</a>
            </li>
            <li>
                <a href="關於我們.php">關於我們</a>
            </li>
            <li>
                <a href="園區展示.php">展館園區</a>
            </li>
            <li>
                <a href="https://forms.office.com/?redirecturl=https%3a%2f%2fforms.office.com%2fPages%2fDesignPageV2.aspx%3fsubpage%3ddesign%26FormId%3dU41DSBo5g0CZfmPnBTOK_YfGmSO2VZZJvBZkxX3XhAxUMEM0UkxBRFBEOUswMFFaV1Y5SkdCMVpSNi4u%26Token%3d0f01876439c24c15be40020cf044967c">問卷調查</a>
            </li>
            <li style="float: right; font-family: Andale Mono, monospace;">
                <?php
                if (isset($_SESSION['username'])) {
                    echo '<div class="dropdown2">';
                    echo '<a href="index.php">' . $_SESSION['username'] . '</a>';
                    echo '<ul class="dropdown-content2">';
                    echo '<li><a href="logout.php">Log Out</a></li>';
                    // 可以加入其他下拉選單項目
                    echo '</ul>';
                    echo '</div>';
                } else {
                    echo '<a href="index.php">Log In</a>';
                }
                ?>
            </li>

            <div class="dropdown">
                <option class="dropbtn" style="font-weight: bold;">書籍類別</option>
                <div class="dropdown-content">
                    <a href="股票.php">股票書籍</a>
                    <a href="不動產.php">不動產書籍</a>
                    <a href="虛擬貨幣.php">虛擬貨幣書籍</a>
                </div>
            </div>
        </ul>
    </nav>

    <hr>
   
    <div>
    <nav class="store1">
        <div class="book3-1">
            <p>▲前進元宇宙!區塊鏈輕旅行</p>
            <a href="post.php"><img src="images/book3-1.png"></a>
        </div>
        <div class="book3-2">
            <p>▲錢包裡的世界史</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=334379"><img src="images/book3-2.png" ></a>
        </div>
        <div class="book3-3">
            <p>▲區塊鏈革命</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=331967"><img src="images/book3-3.png" ></a>
        </div>
        <div class="book3-4">
            <p>▲創富區塊鏈</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=332084"><img src="images/book3-4.png" ></a>
        </div>
        <div class="book3-5">
            <p>▲比特幣投資全書</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=331818"><img src="images/book3-5.png" ></a>
        </div>
        <div class="book3-6">
            <p>▲區塊鏈智能合約與DApp實務應用</p>
            <a href="post.php"><img src="images/book3-6.png"></a>
        </div>
        <div class="book3-7">
            <p>▲一本書玩轉行動支付</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=334379"><img src="images/book3-7.png" ></a>
        </div>
        <div class="book3-8">
            <p>▲互聯網進化史 網路AI超應用</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=331967"><img src="images/book3-8.png" ></a>
        </div>
        <div class="book3-9">
            <p>▲區塊鏈金術</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=332084"><img src="images/book3-9.png" ></a>
        </div>
        <div class="book3-10">
            <p>▲以太,下一波贏家</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=331818"><img src="images/book3-10.png" ></a>
        </div>
    </nav>
    </div>
</body>
</html>