function Utilities() {
    this.apiGet = url => $.ajax(url).then();

    this.apiPost = (url, data) => $.ajax(url).then();

    this.approximate =
        (number, decimals = 3) => {
            let decimalShift = Math.pow(10, decimals);
            return Math.round(decimalShift * number) / decimalShift;
        } 

    this.exist = object => typeof object !== 'undefined' && object !== null;

    this.elementsInArray =
        array =>
            this.exist(array) ?
                (Array.isArray(array) ? array.length > 0 : false) :
                false;
}