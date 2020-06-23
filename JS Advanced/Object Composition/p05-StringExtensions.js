(function solve() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this;
        }
        return this.toString();
    }

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str;
        }
        return this.toString();
    }

    String.prototype.isEmpty = function () {
        return this.length === 0 ? true : false;
    }

    String.prototype.truncate = function (n) {
        if (n <= 3) return '.'.repeat(n);
        if (n >= this.length) return this.toString();
        let spaceIndex = this.substring(0, n - 1).lastIndexOf(" ");
        if (spaceIndex > 0) {
            return this.substring(0, spaceIndex) + "...";
        } else {
            return this.substring(0, n - 3) + "...";
        }
    }

    String.format = function (str, ...params) {
        params.forEach((el, i) => {
            str = str.replace(`{${i}}`, el);
        });
        return str;
    }
}())