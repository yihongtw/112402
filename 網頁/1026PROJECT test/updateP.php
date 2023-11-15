<!doctype html>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <style type="text/css">
        *{margin: 1%}
    </style>
    <title>Document</title>
</head>
<body>
<form method="post" action="upimage.php" enctype="multipart/form-data">
    描述:
    <input type="text" name="form_description" size="40">
    <input type="hidden" name="MAX_FILE_SIZE" value="1000000"> <br>
    上傳檔案到資料庫:
    <input type="file" name="form_data" size="40"><br>
    <input type="submit" name="submit" value="submit">
</form>
</body>
</html>