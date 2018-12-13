function ExcelService() {
    var utilities = new Utilities();
    const urls = {
        excel: '/api/Excel'
    }

    this.getExcel =
        data => utilities.apiPost(urls.excel, data).then(responce => window.navigator.msSaveBlob(responce, 'Proyección.xlsx'));
}
