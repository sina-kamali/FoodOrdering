export module EnumsHelpers {
  export function getNamesAndValues<T extends number>(e: any) {
    return getNames(e).map(n => ({ name: n, value: e[n] as T }));
  }

  export function getNames(e: any) {
    return getObjValues(e).filter(v => typeof v === 'string') as string[];
  }

  export function getValues<T extends number>(e: any) {
    return getObjValues(e).filter(v => typeof v === 'number') as T[];
  }

  function getObjValues(e: any): (number | string)[] {
    return Object.keys(e).map(k => e[k]);
  }
}
