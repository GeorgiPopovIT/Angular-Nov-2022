"use strict";
exports.__esModule = true;
var Box = /** @class */ (function () {
    function Box() {
        this._boxes = [];
    }
    Box.prototype.add = function (element) {
        this._boxes.push(element);
    };
    Box.prototype.remove = function () {
        this._boxes.pop();
    };
    Box.prototype.getCount = function () {
        return this._boxes.length;
    };
    return Box;
}());
exports["default"] = Box;
var box = new Box();
box.add(1);
box.add(2);
box.add(3);
console.log(box.getCount());
box.remove();
console.log(box.getCount());
