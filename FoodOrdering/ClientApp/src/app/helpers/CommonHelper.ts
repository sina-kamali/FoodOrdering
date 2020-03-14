export module CommonHelper {

  export function isNotNullEmptyUndefined(element: any): boolean {
    if (element != null && element != undefined) {
      const isArray = Array.isArray(element);
      const elemetType = typeof (element);

      if (elemetType == 'string' && element.trim() == '')
        return false;

      if (isArray && element.length > 0)
        return true;
      else if (isArray && element.length == 0)
        return false;
      else if (!isArray)
        return true;
    }

    return false;
  }

  export function generateCheckFromPOS(posChk: any) {

    let item = {};
    item['CheckNumber'] = posChk.CheckNumber;
    item['Status'] = posChk.Status;
    item['TaxTotal'] = posChk.TaxTotal;

    var isFullyPaid = 0;

    if (getCheckBalanceOwing(posChk) <= 0) {
      isFullyPaid = 1;
    }

    item['IsFullyPaid'] = isFullyPaid;
    item['SubTotal'] = posChk.SubTotal;

    return item
  }


  export function getCheckTotal(chk: any): number {
    var length = 0;

    var runningTotal = CommonHelper.addNumbers(Number(chk.TaxTotal), Number(chk.SubTotal));

    runningTotal = CommonHelper.addNumbers(runningTotal, getCheckGratuityAmount(chk));

    return runningTotal;
    //return chk.TaxTotal + chk.SubTotal + getCheckGratuityAmount(chk);
  }

  export function getCheckGratuityAmount(chk: any): number {

    var gratTotal = 0;

    if (chk.Gratuities != null && chk.Gratuities.length > 0) {
      for (var i = 0; i < chk.Gratuities.length; i++) {
        var chkGrat: any = chk.Gratuities[i];

        gratTotal = CommonHelper.addNumbers(gratTotal, Number(chkGrat.Amount));

        //gratTotal += chkGrat.Amount;
      }
    }

    return gratTotal;
  }

  /// gets net
  export function sumPaymentNetAmounts(payments: []): number {

    var total = 0;

    if (payments != null && payments.length > 0) {

      for (var i = 0; i < payments.length; i++) {
        let chkPay: any = payments[i];

        var netPayAmt = CommonHelper.substractNumbers(Number(chkPay.PayAmount), Number(chkPay.TipAmount));
        total = CommonHelper.addNumbers(total, netPayAmt);

        //var netPayAmt = chkPay.PayAmount - chkPay.TipAmount;
        //total += netPayAmt;
      }
    }

    return total;
  }

  export function calculateCheckPaymentsNetAmount(chk: any) {

    var appliedAmt = sumPaymentNetAmounts(chk.Payments);
    return appliedAmt;

  }

  export function getCheckBalanceOwing(chk: any): number {

    var balanceOwing = 0;
    var total = getCheckTotal(chk);

    balanceOwing = CommonHelper.substractNumbers(total, calculateCheckPaymentsNetAmount(chk));

    //balanceOwing = total - calculateCheckPaymentsNetAmount(chk, incomigPayments);
    // round to 2 decimals
    return CommonHelper.roundDecimal(balanceOwing);
  }

  export enum ArithmeticOperation {
    Add,
    Substract,
    Multiply,
    Divide
  }

  export function addNumbers(a: number, b: number): number {
    return doOperation(a, b, ArithmeticOperation.Add);
  }

  export function substractNumbers(a: number, b: number): number {
    return doOperation(a, b, ArithmeticOperation.Substract);
  }

  export function multiplyDecimals(a: number, b: number): number {
    return doOperation(a, b, ArithmeticOperation.Multiply);
  }

  export function divideNumbers(a: number, b: number): number {
    return doOperation(a, b, ArithmeticOperation.Divide);
  }

  export function doOperation(a: number, b: number, operation: ArithmeticOperation): number {

    var atens = 1;
    var btens = 1;

    if (String(a).indexOf('.') != -1) {
      // we have a decimal
      atens = Math.pow(10, String(a).length - String(a).indexOf('.') - 1);
    }

    if (String(b).indexOf('.') != -1) {
      // we have a decimal
      btens = Math.pow(10, String(b).length - String(b).indexOf('.') - 1);
    }

    var finalTens = Math.max(atens, btens);

    //var aVal = Math.ceil((a * finalTens));
    //var bVal = Math.ceil((b * finalTens));

    var aVal = Math.round(a * finalTens);
    var bVal = Math.round(b * finalTens);

    if (operation == ArithmeticOperation.Add)
      return (aVal + bVal) / finalTens;
    else if (operation == ArithmeticOperation.Multiply)
      return (aVal * bVal) / (finalTens * finalTens);
    else if (operation == ArithmeticOperation.Substract)
      return (aVal - bVal) / finalTens;
    else if (operation == ArithmeticOperation.Divide) {
      var result = aVal / bVal;


      return result; // not tested
    }
  }

  export function roundDecimal(amount: number): number {

    var isNegative = amount < 0;

    //// We need to round to 3 decimal places first...
    //var amount3Places = decimalAdjust('round',  Math.abs(amount), -3);

    // Then we round to 2 decimal places...
    var rounded = decimalAdjust('round', Math.abs(amount), -2);

    if (isNegative == true) {
      return rounded * -1;
    }
    return rounded;

    //return Math.round(amount * 100) / 100;
  }

  /*
      https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Math/round
  */
  export function decimalAdjust(type, value, exp) {
    // If the exp is undefined or zero...
    if (typeof exp === 'undefined' || +exp === 0) {
      return Math[type](value);
    }
    value = +value;
    exp = +exp;
    // If the value is not a number or the exp is not an integer...
    if (isNaN(value) || !(typeof exp === 'number' && exp % 1 === 0)) {
      return NaN;
    }
    // Shift
    value = value.toString().split('e');
    value = Math[type](+(value[0] + 'e' + (value[1] ? (+value[1] - exp) : -exp)));
    // Shift back
    value = value.toString().split('e');
    return +(value[0] + 'e' + (value[1] ? (+value[1] + exp) : exp));
  }
}
