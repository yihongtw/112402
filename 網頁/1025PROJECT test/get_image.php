<?php
// 在这里连接到你的数据库
$servername = "localhost"; // 数据库服务器名称
$username = "root"; // 数据库用户名
$password = ""; // 数据库密码
$dbname = "112402"; // 数据库名称

/// 创建连接
$conn = new mysqli($servername, $username, $password, $dbname);

// 检查连接是否成功
if ($conn->connect_error) {
    die("连接失败: " . $conn->connect_error);
}

$response = array(); // 创建一个数组来存储响应数据

if (isset($_POST['selected_book'])) {
    // 获取用户选择的书籍名称
    $selectedBook = $_POST['selected_book'];

    // 查询数据库以获取所选书籍的图像文件名和介绍
    $sql = "SELECT filename, introduction FROM ccs_image WHERE description = '$selectedBook'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        // 获取结果行
        $row = $result->fetch_assoc();

        // 存储文件名和介绍到响应数组
        $response['filename'] = $row['filename'];
        $response['introduction'] = $row['introduction'];
    }
}

// 关闭数据库连接
$conn->close();

// 将响应数据编码为 JSON 格式并输出
echo json_encode($response);
?>
