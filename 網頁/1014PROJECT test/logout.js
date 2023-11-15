var isDropdownVisible = false;

function showDropdown() {
  var dropdownContent = document.getElementById('dropdownContent');
  dropdownContent.style.display = 'block';
  isDropdownVisible = true;
}

function hideDropdown() {
  if (!isMouseOverDropdown()) {
    var dropdownContent = document.getElementById('dropdownContent');
    dropdownContent.style.display = 'none';
    isDropdownVisible = false;
  }
}

function isMouseOverDropdown() {
  var usernameDropdown = document.getElementById('usernameDropdown');
  var dropdownContent = document.getElementById('dropdownContent');
  var boundingBox = usernameDropdown.getBoundingClientRect();

  var mouseX = event.clientX;
  var mouseY = event.clientY;

  return (
    mouseX >= boundingBox.left &&
    mouseX <= boundingBox.right &&
    mouseY >= boundingBox.top &&
    mouseY <= boundingBox.bottom
  );
}

// 添加事件監聽器，以便在滑鼠進入下拉內容時保持下拉內容可見
var dropdownContent = document.getElementById('dropdownContent');
dropdownContent.addEventListener('mouseover', function () {
  showDropdown();
});

// 添加事件監聽器，以便在滑鼠離開整個區域時隱藏下拉內容
var usernameDropdown = document.getElementById('usernameDropdown');
usernameDropdown.addEventListener('mouseout', function () {
  if (!isMouseOverDropdown()) {
    hideDropdown();
  }
});
