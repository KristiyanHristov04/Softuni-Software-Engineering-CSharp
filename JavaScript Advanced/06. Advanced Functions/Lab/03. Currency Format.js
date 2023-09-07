function createFormatter(separator, symbol, symbolFirst, fn) {
    let newFn = fn.bind(null, separator, symbol, symbolFirst);
    return newFn;
}