function ensureChecked(source, args) {
    var boxes = $('#ctl00_ContentPlaceHolder1_ContractsCheckBoxList').find('input:checkbox:checked');
    if (boxes.length == 0) {
        source.IsValid = false;
        args.IsValid = false;
    }
    else {
        source.IsValid = true;
        args.IsValid = true;
    }
    return args.IsValid;
}