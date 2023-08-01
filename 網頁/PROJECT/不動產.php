<?php
session_start();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>不動產</title>
    <link rel="stylesheet" href="Newstyle.css">
</head>
<body>
    <nav>
        <ul>
            <li> <a href="">虛擬世界的書架</a> </li>
            </li>
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
            <li style="float: right;font-family: Andale Mono, monospace;">
                <?php
                if (isset($_SESSION['fullname'])) {
                    echo '<a href="index.php">' . $_SESSION['fullname'] . '</a>';
                } else {
                    echo '<a href="index.php">Log In</a>';
                }
                ?>
            </li>
            <div class="dropdown" >
                <option class="dropbtn" style="font-weight: bold;">書籍類別</option>
                <div class="dropdown-content">
                    <a href="股票.php">股票書籍</a>
                    <a href="不動產.php">不動產書籍</a>
                    <a href="虛擬貨幣.php">虛擬貨幣書籍</a>
                </div>
            </div>
        </ul>
    </nav>
    <div>
        <p>不動產書籍</p>
    </div>
</body>
</html>