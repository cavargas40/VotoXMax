function popupCalendar() {
    var dateField = document.getElementById('dateField');

    // toggle the div
    if (dateField.style.display == 'none')
        dateField.style.display = 'block';
    else
        dateField.style.display = 'none';
}