"use strict";
exports.__esModule = true;
var KeyValuePair = /** @class */ (function () {
    function KeyValuePair() {
    }
    KeyValuePair.prototype.setKeyValuePair = function (key, value) {
        this.key = key;
        this.value = value;
    };
    KeyValuePair.prototype.display = function () {
        return "key = ".concat(this.key, ", value = ").concat(this.value);
    };
    return KeyValuePair;
}());
exports["default"] = KeyValuePair;
var kvp = new KeyValuePair();
kvp.setKeyValuePair(1, "Pesho");
console.log(kvp.display());
