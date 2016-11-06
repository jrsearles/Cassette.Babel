import {transform} from "babel-standalone";

export function CassetteBabel_Transpile(code, options) {
  return transform(code, JSON.parse(options)).code;
}