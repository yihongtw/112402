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
    <title>新不動產</title>
    <!-- 連結CSS外部檔案 -->
    <link rel="stylesheet" href="Newstyle.css">
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
                <a href="">問卷調查</a>
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

    
    <form style="width:500px; height:550px; background-color:#E8E8E8; position:absolute;right:500px;border-radius:45px" action="" method="post">
        <label style="position: absolute;right:350px" for="selected_book">請選擇書籍：</label>
        <select style="position: absolute;right:115px" id="selected_book" name="selected_book" onchange="showImage()">
            <option value="B3-1">▲前進元宇宙!區塊鏈輕旅行</option>
            <option value="B3-2">▲錢包裡的世界史</option>
            <option value="B3-3">▲區塊鏈革命</option>
            <option value="B3-4">▲創富區塊鏈</option>
            <option value="B3-5">▲比特幣投資全書</option>
            <option value="B3-6">▲區塊鏈智能合約與DApp實務應用</option>
            <option value="B3-7">▲一本書玩轉行動支付</option>
            <option value="B3-8">▲互聯網進化史 網路AI超應用</option>
            <option value="B3-9">▲區塊鏈金術</option>
            <option value="B3-10">▲以太,下一波贏家</option>
        </select>
        <button style="position: absolute;left:390px;text-decoration:none;" ><a style="text-decoration:none" id="share_button" href="#">心得分享</a></button>
    </form>
    
    <div id="bookImageContainer" class="book-image-container">
        <!-- 这里将显示图像 -->
    </div>

    <script>
        // 添加事件监听器，选择不同书籍时更新分享链接
        document.getElementById("selected_book").addEventListener("change", updateShareLink);

        function updateShareLink() {
            var selectedBook = document.getElementById("selected_book").value;
            var shareButton = document.getElementById("share_button");

            // 构建心得评价页面链接
            var reviewPageLink = "post" + encodeURIComponent(selectedBook) + ".php";

            // 更新按钮链接
            shareButton.setAttribute("href", reviewPageLink);
        }

        function showImage() {
            var selectedBook = document.getElementById("selected_book").value;
            var bookImageContainer = document.getElementById("bookImageContainer");

            // 在这里连接到你的数据库
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function() {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    var imageFilename = xhr.responseText;
                    if (imageFilename) {
                        // 显示图像
                        var img = document.createElement("img");
                        img.src = "images/" + imageFilename;
                        img.alt = selectedBook;
                        bookImageContainer.innerHTML = ""; // 清空容器
                        bookImageContainer.appendChild(img);
                    } else {
                        bookImageContainer.innerHTML = "未找到所选书籍的图像。";
                    }
                }
            };

            xhr.open("POST", "get_image.php", true);
            xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xhr.send("selected_book=" + selectedBook);
        }

        // 在页面加载时触发一次，以显示初始的分享链接
        window.onload = updateShareLink;
    </script>
      <footer>
        <p>Copyright © 2023 NTUB IMD 112402. All rights reserved.</p>
    </footer>
</body>

</html>