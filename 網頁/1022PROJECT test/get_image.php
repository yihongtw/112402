<?php
// 在这里连接到你的数据库
$servername = "localhost"; // 数据库服务器名称
$username = "root"; // 数据库用户名
$password = ""; // 数据库密码
$dbname = "112402"; // 数据库名称

// 创建连接
$conn = new mysqli($servername, $username, $password, $dbname);

// 检查连接是否成功
if ($conn->connect_error) {
    die("连接失败: " . $conn->connect_error);
}

if (isset($_POST['selected_book'])) {
    // 获取用户选择的书籍名称
    $selectedBook = $_POST['selected_book'];

    // 查询数据库以获取所选书籍的图像文件名
    $sql = "SELECT filename FROM ccs_image WHERE description = '$selectedBook'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        // 输出图像文件名
        $row = $result->fetch_assoc();
        $imageFilename = $row['filename'];
        echo $imageFilename;
    } else {
        echo ''; // 如果未找到图像文件名，返回空字符串
    }
}

// 关闭数据库连接
$conn->close();
?>
