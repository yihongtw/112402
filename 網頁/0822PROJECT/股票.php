<?php
session_start();
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>股票</title>
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
    <nav class="store1">
        <div class="book1-1">
            <p>▲開始在股市賺錢最要緊的大小事</p>
            <a href="post.php"><img src="images/book1-1.png"></a>
        </div>
        <div class="book1-2">
            <p>▲投資中最簡單的事</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=334379"><img src="images/book1-2.png" ></a>
        </div>
        <div class="book1-3">
            <p>▲持續買進</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=331967"><img src="images/book1-3.png" ></a>
        </div>
        <div class="book1-4">
            <p>▲槓桿ETF投資法</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=332084"><img src="images/book1-4.png" ></a>
        </div>
        <div class="book1-5">
            <p>▲華爾街的華爾滋</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=331818"><img src="images/book1-5.png" ></a>
        </div>
        <div class="book1-6">
            <p>▲Excel 選股法</p>
            <a href="post.php"><img src="images/book1-6.png"></a>
        </div>
        <div class="book1-7">
            <p>▲全息人生</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=334379"><img src="images/book1-7.png" ></a>
        </div>
        <div class="book1-8">
            <p>▲3天搞懂買賣股票</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=331967"><img src="images/book1-8.png" ></a>
        </div>
        <div class="book1-9">
            <p>▲Python股票xETF量化交易</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=332084"><img src="images/book1-9.png" ></a>
        </div>
        <div class="book1-10">
            <p>▲漫步股市:給存股族的12個致富心法</p>
            <a href="https://ebook.hyread.com.tw/bookDetail.jsp?id=331818"><img src="images/book1-10.png" ></a>
        </div>
    </nav>
</body>

</html>