document.querySelectorAll('.datetimepicker').forEach((item) => {
    flatpickr(item, getData(item, 'options'));
});