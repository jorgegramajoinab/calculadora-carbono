function Utilities() {
    this.apiGet = url => $.ajax(url).then();

    this.apiPost = (url, data) => $.ajax(url).then();
}