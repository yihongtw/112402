
    <?php
    if (isset($_POST['submit'])) {
    $form_description = $_POST['form_description'];
    $form_data_name = $_FILES['form_data']['name'];
    $form_data = $_FILES['form_data']['tmp_name'];
    $form_data_size = $_FILES['form_data']['size'];
    $form_data_type = $_FILES['form_data']['type'];

    $dsn = 'mysql:dbname=112402;host=localhost';
    $pdo = new PDO($dsn, 'root', '');

    // 將圖片數據編碼為Base64格式
    $data = base64_encode(file_get_contents($form_data));

    $result = $pdo->query("INSERT INTO ccs_image (description, bin_data, filename,filesize,filetype)
                  VALUES ('$form_description', '$data', '$form_data_name','$form_data_size','$form_data_type')");
    if ($result) {
        echo "圖片已儲存到資料庫";

        // 從資料庫檢索圖片數據時，使用 base64_decode 解碼
        $retrieved_data = base64_decode($data);

        // 在HTML中顯示圖片
        echo '<img src="data:image/jpeg;base64,' . base64_encode($retrieved_data) . '" />';
    } else {
        echo "請求失敗，請重試";
    }
}
?>