<?php
if (isset($_POST['submit'])) {
    $form_description = $_POST['form_description'];
    $form_data_name = $_FILES['form_data']['name'];
    $form_data_size = $_FILES['form_data']['size'];
    $form_data_type = $_FILES['form_data']['type'];
    $form_data = $_FILES['form_data']['tmp_name'];
    
    $dsn = 'mysql:dbname=112402;host=localhost';
    $pdo = new PDO($dsn, 'root', '');
    $data = addslashes(fread(fopen($form_data, "r"), filesize($form_data)));
    //echo "mysqlPicture=".$data;
    
    $result = $pdo->query("INSERT INTO ccs_image (description,bin_data,filename,filesize,filetype)
                  VALUES ('$form_description','$data','$form_data_name','$form_data_size','$form_data_type')");
    if ($result) {
        echo "圖片已儲存到資料庫";
    } else {
        echo "請求失敗,請重試";
    }
}
?>