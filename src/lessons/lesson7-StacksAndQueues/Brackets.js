/**
 * A string S consisting of N characters is considered to be properly nested if any of the following conditions is true:
 * S is empty;
 * S has the form "(U)" or "[U]" or "{U}" where U is a properly nested string;
 * S has the form "VW" where V and W are properly nested strings.
 * For example, the string "{[()()]}" is properly nested but "([)()]" is not.
 * Write a function:
 * function solution(S);
 * that, given a string S consisting of N characters, returns 1 if S is properly nested and 0 otherwise.
 * For example, given S = "{[()()]}", the function should return 1 and given S = "([)()]", the function should return 0, as explained above.
 * Write an efficient algorithm for the following assumptions:
 * N is an integer within the range [0..200,000];
 * string S consists only of the following characters: "(", "{", "[", "]", "}" and/or ")".
 */

function checkBrackets(left, right) {
    return (
        (left === "(" && right === ")") ||
        (left === "[" && right === "]") ||
        (left === "{" && right === "}")
    );
}

/** Detected time complexity: O(N) 100% */
function isNested(str) {
    const arr = str.split("");
    let stack = [];
    arr.forEach((value) => {
        if (stack.length !== 0) {
            let lastValue = stack.pop();
            if (!checkBrackets(lastValue, value)) {
                stack.push(lastValue);
                stack.push(value);
            }
        } else {
            stack.push(value);
        }
    });
    return stack.length === 0 ? 1 : 0;
}

function solution(S) {
    return isNested(S);
}

console.log(solution("{[()()]}")); // 1
console.log(solution("([)()]")); // 0
