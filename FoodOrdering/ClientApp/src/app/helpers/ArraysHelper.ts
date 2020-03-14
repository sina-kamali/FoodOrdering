export module ArraysHelper {

  export function find<T>(array: T[], item: T): T {
    var length = 0;

    if (array != null) {
      length = array.length
    }

    for (var i = 0; i < length; i++) {
      var val = array[i];
      if (item === val) {
        return val;
      }
    }
  }

  export function indexOf<T>(array: T[], callback: (item: T) => boolean): number {
    var length = 0;

    if (array != null) {
      length = array.length;
    }

    for (let i = 0; i < length; i++) {
      var val = array[i];
      if (callback(val) === true) {
        return i;
      }
    }

    return -1;
  }

  export function forEach<T>(array: T[], callback: (item: T) => void): void {
    var length = 0;

    if (array != null) {
      length = array.length;
    }

    for (var i = 0; i < length; i++) {
      callback(array[i]);
    }
  }

  export function forEachTill<T>(array: T[], callback: (item: T) => boolean): void {
    var length = 0;

    if (array != null) {
      length = array.length
    }

    for (var i = 0; i < length; i++) {
      if (callback(array[i]) === false) {
        return;
      }
    }
  }

  export function firstOrDefault<T>(array: T[], callback: (item: T) => boolean): T {
    var length = 0;

    if (array != null) {
      length = array.length
    }

    for (var i = 0; i < length; i++) {
      var val = array[i];
      if (callback(val) === true) {
        return val;
      }
    }

    return null;
  }

  export function where<T>(array: T[], callback: (item: T) => boolean): T[] {
    var length = 0;

    if (array != null) {
      length = array.length
    }


    var items: T[] = [];
    for (var i = 0; i < length; i++) {
      var val = array[i];
      if (callback(val) == true) {
        items.push(val);
      }
    }
    return items;
  }

  export function count<T>(array: T[], callback: (item: T) => boolean): number {
    let length = 0;

    if (array != null) {
      length = array.length;
    }

    let result: number;
    result = 0;

    for (var i = 0; i < length; i++) {
      var val = array[i];
      if (callback(val) == true) {
        result += 1;
      }
    }
    return result;
  }



  /**
   * sorts original array
   * @param array
   * @param sortBy
   */
  export function sortAsc<T>(array: T[], sortBy: string): void {
    array.sort((a, b) => { return a[sortBy] > b[sortBy] ? 1 : (a[sortBy] < b[sortBy] ? -1 : 0); });
  }

  export function sortDesc<T>(array: T[], sortBy: string): void {
    array.sort((a, b) => { return a[sortBy] < b[sortBy] ? 1 : (a[sortBy] > b[sortBy] ? -1 : 0); });
  }

  export function sortAscMultiple<T>(array: T[], sortByProps: string[]): void {

    array.sort((a, b) => {

      var fieldAPoints = 0;
      var fieldBPoints = 0;

      for (var i = 0; i < sortByProps.length; i++) {
        var fieldA = a[sortByProps[i]];
        var fieldB = b[sortByProps[i]];

        var pointsFactor = Math.pow(10, sortByProps.length - (i + 1));

        if (fieldA > fieldB)
          fieldAPoints += pointsFactor;
        else if (fieldA < fieldB)
          fieldBPoints += pointsFactor;
        else
          fieldBPoints += 0;
      }

      return fieldAPoints > fieldBPoints ? 1 : (fieldAPoints < fieldBPoints ? -1 : 0);
    });
  }

  /*
      can sort array of objects with child propertry
      eg. To sort by property of object table, sortNatural(tableOrders, 'table.Name')
  */
  export function sortNatural<T>(array: T[], sortBy: string): void {

    var getNestedProperty = function (o, s) {
      s = s.replace(/\[(\w+)\]/g, '.$1'); // convert indexes to properties
      s = s.replace(/^\./, '');           // strip a leading dot
      var a = s.split('.');
      for (var i = 0, n = a.length; i < n; ++i) {
        var k = a[i];
        if (k in o) {
          o = o[k];
        } else {
          return;
        }
      }
      return o.toString();
    }


    array.sort(function (a, b) {
      var ax = [], bx = [];

      getNestedProperty(a, sortBy).replace(/(\d+)|(\D+)/g, function (_, $1, $2) { ax.push([$1 || Infinity, $2 || ""]) });
      getNestedProperty(b, sortBy).replace(/(\d+)|(\D+)/g, function (_, $1, $2) { bx.push([$1 || Infinity, $2 || ""]) });

      while (ax.length && bx.length) {
        var an = ax.shift();
        var bn = bx.shift();
        var nn = (an[0] - bn[0]) || an[1].localeCompare(bn[1]);
        if (nn) return nn;
      }

      return ax.length - bx.length;
    });
  }


}
