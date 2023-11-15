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
  <title>園區展示</title>
  <!-- 連結CSS外部檔案 -->
  <link rel="stylesheet" href="Newstyle.css">
  <link rel="stylesheet" href="@/TeamplateData/style.css">
  <script type="text/javascript" src="logout.js"></script>
</head>

<body>
  <nav>
  <div class="logo"> <img src="images/Logo1025.png" style="width: 400px;height:140px"></div>
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
  <section>
    <div>
      <div id="unity-container" class="unity-desktop">
        <canvas id="unity-canvas" ></canvas>
        <div id="unity-loading-bar">
          <div id="unity-logo"></div>
          <div id="unity-progress-bar-empty">
            <div id="unity-progress-bar-full"></div>
          </div>
        </div>
        <div id="unity-warning"> </div>
        <div id="unity-footer">
          <div id="unity-webgl-logo"></div>
          <div id="unity-fullscreen-button"></div>
          <!-- <div id="unity-build-title">Project</div> -->
        </div>
      </div>
      <script>
        var container = document.querySelector("#unity-container");
        var canvas = document.querySelector("#unity-canvas");
        var loadingBar = document.querySelector("#unity-loading-bar");
        var progressBarFull = document.querySelector("#unity-progress-bar-full");
        var fullscreenButton = document.querySelector("#unity-fullscreen-button");
        var warningBanner = document.querySelector("#unity-warning");

        function unityShowBanner(msg, type) {
          function updateBannerVisibility() {
            warningBanner.style.display = warningBanner.children.length ? 'block' : 'none';
          }
          var div = document.createElement('div');
          div.innerHTML = msg;
          warningBanner.appendChild(div);
          if (type == 'error') div.style = 'background: red; padding: 10px;';
          else {
            if (type == 'warning') div.style = 'background: yellow; padding: 10px;';
            setTimeout(function() {
              warningBanner.removeChild(div);
              updateBannerVisibility();
            }, 5000);
          }
          updateBannerVisibility();
        }

        var buildUrl = "Build";
        var loaderUrl = buildUrl + "/WEB.loader.js";
        var config = {
          dataUrl: buildUrl + "/WEB.data",
          frameworkUrl: buildUrl + "/WEB.framework.js",
          codeUrl: buildUrl + "/WEB.wasm",
          streamingAssetsUrl: "StreamingAssets",
          companyName: "DefaultCompany",
          productName: "Project",
          productVersion: "0.1",
          showBanner: unityShowBanner,
        };

        if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
          var meta = document.createElement('meta');
          meta.name = 'viewport';
          meta.content = 'width=device-width, height=device-height, initial-scale=1.0, user-scalable=no, shrink-to-fit=yes';
          document.getElementsByTagName('head')[0].appendChild(meta);
          container.className = "unity-mobile";


          canvas.style.width = window.innerWidth + 'px';
          canvas.style.height = window.innerHeight + 'px';

          unityShowBanner('WebGL builds are not supported on mobile devices.');
        } else {
          canvas.style.width = "1536px";
          canvas.style.height = "530px";
        }

        loadingBar.style.display = "block";

        var script = document.createElement("script");
        script.src = loaderUrl;
        script.onload = () => {
          createUnityInstance(canvas, config, (progress) => {
            progressBarFull.style.width = 100 * progress + "%";
          }).then((unityInstance) => {
            loadingBar.style.display = "none";
            fullscreenButton.onclick = () => {
              unityInstance.SetFullscreen(1);
            };
          }).catch((message) => {
            alert(message);
          });
        };
        document.body.appendChild(script);
      </script>
    </div>
  </section>
  <footer>
    <p>Copyright © 2023 NTUB IMD 112402. All rights reserved.</p>
  </footer>
</body>

</html>