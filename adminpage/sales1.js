
function calculate() {
    
    var ea1=document.getElementsByClassName('txtea1')[0].value;         //className이 txtea1인 요소를 변수 ea1로 지정한다.
    var price1=document.getElementsByClassName('txtprice1')[0].value;   //className이 txtprice1인 요소를 변수 price1로 지정한다.
    
    // 콤마( , )의 경우도 문자로 인식되기 때문에 콤마를 따로 제거한다.
    var ea2=ea1.replace(/\,/g, "");         
    var price2=price1.replace(/\,/g, ""); 
    
    var supply1=parseInt(ea2)*parseInt(price2);   //문자열을 숫자열로 변환하여 공급가액을 계산

    var vat1=supply1*0.1;        //(공급가액 * 0.1)을 하여 부가세 계산
    
    var total1=supply1+vat1;     //(공급가액 + 부가세)를 하여 합계 계산
    
    //공급가액, 부가세, 합계가 계산될 때 자동으로 천 단위 콤마(,)표시
    var supply2=supply1.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","); 
    var vat2=vat1.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    var total2=total1.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    
    document.getElementsByClassName('txtsupply1')[0].value=supply2;     //천 단위 콤마(,) 표시가 된 값을 ClassName이 txtsupply1인 요소에 반환
    document.getElementsByClassName('txtvat1')[0].value=vat2;           //천 단위 콤마(,) 표시가 된 값을 ClassName이 txtvat1인 요소에 반환
    document.getElementsByClassName('txttotal1')[0].value=total2;       //천 단위 콤마(,) 표시가 된 값을 ClassName이 txttotal1인 요소에 반환
}


function inputNumberAutoComma(obj) {  //수량, 단가를 입력할 때 자동으로 천 단위 콤마(,) 표시를 해주는 함수
       
    // 콤마( , )의 경우도 문자로 인식되기때문에 계산을 할 때는 콤마(,)를 따로 제거해주어야한다.
    var deleteComma = obj.value.replace(/\,/g, "");

    

    //입력된 문자에 콤마( , )를 제외되었는지를 확인한다.
    if(isFinite(deleteComma) == false) {
        alert("문자는 입력하실 수 없습니다.");
        obj.value = "";
        return false;
    }
   
    // 기존에 들어가있던 콤마( , )를 제거한 후의 입력값에 다시 콤마( , )를 삽입한다.
    obj.value = inputNumberWithComma(inputNumberRemoveComma(obj.value));
}

// 천단위 이상의 숫자에 콤마( , )를 삽입하는 함수
function inputNumberWithComma(str) {

    str = String(str);
    return str.replace(/(\d)(?=(?:\d{3})+(?!\d))/g, "$1,");
}

// 콤마( , )가 들어간 값에 콤마를 제거하는 함수
function inputNumberRemoveComma(str) {

    str = String(str);
    return str.replace(/[^\d]+/g, "");
}



var sum = {  //객체 sum으로 unicode의 집합이 배열 형태로 지정
    //{}안에 있는 수량, 단가, 공급가액, 부가세, 합계 data를 한글 김가연을 unicode로 변환한 key값으로 불러옴
    'ae40ac00c5f0': {ea: 0, price: 0, supply: 0, vat: 0, total: 0}, 
    'c624bbfcc900': {ea: 0, price: 0, supply: 0, vat: 0, total: 0},
    'c774c815d604': {ea: 0, price: 0, supply: 0, vat: 0, total: 0},
    'c7a5c9c0c778': {ea: 0, price: 0, supply: 0, vat: 0, total: 0}
}; 

var getSum = () => {
    // 클래스명이 salesman인 박스를 배열에 저장
    var salesman = document.getElementsByClassName('salesman');
    // 동일한 방식으로 계산할 박스들을 각각의 배열에 저장
    var ea = document.getElementsByClassName('ea');
    var price = document.getElementsByClassName('price');
    var supply = document.getElementsByClassName('supply');
    var vat = document.getElementsByClassName('vat');
    var total = document.getElementsByClassName('total');

    for (var i=0; i<salesman.length; i++) {  //data 개수만큼 반복 실행
        var name = salesman[i].innerHTML.trim(); // salesman 내부 담당자명 공백제거
        var uni = makeToUni(name); // 에러방지를 위해 한글화된 이름을 유니코드화 (해당 함수는 아래에 정의)
        if (uni == 'ae40ac00c5f0') { // 미리 저장된 코드에 맞추어 조건문 실행
            valFilter(i, uni, ea, price, supply, vat, total); // 각각의 수량, 단가, 공급가, 부가세, 합계를 매개변수로 필터링 함수 실행
        } 
        else if (uni == 'c624bbfcc900') {
            valFilter(i, uni, ea, price, supply, vat, total);
        }
        else if (uni == 'c774c815d604') {
            valFilter(i, uni, ea, price, supply, vat, total);
        }
        else if (uni == 'c7a5c9c0c778') {
            valFilter(i, uni, ea, price, supply, vat, total);
        }
    }
    
    for (let i=0; i<sum.length; i++) { // 첫번째 for문의 전처리 과정으로 sum 객체에 저장된 값에 세 자리마다 끊어 ','추가
        sum[i].ea = addComma(sum[i].ea); 
        sum[i].price = addComma(sum[i].price);
        sum[i].supply = addComma(sum[i].supply);
        sum[i].vat = addComma(sum[i].vat);
        sum[i].total = addComma(sum[i].total);
    } 
    // getSum 모듈 종료 (리스트 합 계산)
}


// 받은 string 값을 유니코드화 하는 함수
var makeToUni = (str) => {
    var lis = [];
    for (let i=0; i<str.length; i++) {
        lis.push(str[i].charCodeAt(0).toString(16));
    }
    return lis.join("");
}


// 받은 수량, 단가, 공급가, 부가세, 합계를 매개변수로 필터링 작업을 하는 전처리 진행
//(공백을 제거하고 ','기준으로 문자를 분리(배열화)한 후, 다시 문자열로 합침)
var valFilter = (i, uni, ea, price, supply, vat, total) => {
    var ea_filtered =  ea[i].innerHTML.trim().split(',').join("");
    var price_filtered =  price[i].innerHTML.trim().split(',').join("");
    var supply_filtered =  supply[i].innerHTML.trim().split(',').join("");
    var vat_filtered =  vat[i].innerHTML.trim().split(',').join("");
    var total_filtered = total[i].innerHTML.trim().split(',').join("");

    sum[uni].ea += parseInt(ea_filtered); //  전처리된 값들을 문자열을 숫자로 변환한 후, 객체 sum의 각각의 값에 더하여 저장,
    sum[uni].price += parseInt(price_filtered);
    sum[uni].supply += parseInt(supply_filtered);
    sum[uni].vat += parseInt(vat_filtered);
    sum[uni].total += parseInt(total_filtered);
}

var addComma = (num) => { // 3자리마다 숫자에 콤마를 추가하는 함수
    var regexp = /\B(?=(\d{3})+(?!\d))/g;
    return num.toString().replace(regexp, ',');
  }

// 화면에 합을 프린트 해주는 모듈
var printSum = () => {
    var lastOne1; // 각 담당자의 마지막 행을 저장할 변수 정의
    var lastOne2;
    var lastOne3;
    var lastOne4;
    var salesman = document.getElementsByClassName('salesman'); // 담당자 명이 담겨있는 박스 호출
    for (var i=0; i<salesman.length; i++) {
        var name = salesman[i].innerHTML.trim(); // 담당자 명 전처리(공백제거)
        var uni = makeToUni(name); // 에러방지를 위해 담당자 명을 유니코드로 변환

        // 각각의 담당자 명에 대한 마지막 행을 찾아 변수에 저장하는 조건문
        if (uni == 'ae40ac00c5f0') {
            lastOne1 = salesman[i];
        }
        if (uni == 'c624bbfcc900') {
            lastOne2 = salesman[i];
        }
        if (uni == 'c774c815d604') {
            lastOne3 = salesman[i];
        }
        if (uni == 'c7a5c9c0c778') {
            lastOne4 = salesman[i];
        }
    }
console.log(lastOne1)
    // 각각의 변수에 저장된 마지막 행의 다음 행을 만드는 함수 실행
    if (lastOne1 != undefined) {
        makeList(lastOne1, sum['ae40ac00c5f0'].ea, sum['ae40ac00c5f0'].price, sum['ae40ac00c5f0'].supply, sum['ae40ac00c5f0'].vat, sum['ae40ac00c5f0'].total);
    }
    if (lastOne2 != undefined) {
        makeList(lastOne2, sum['c624bbfcc900'].ea, sum['c624bbfcc900'].price, sum['c624bbfcc900'].supply, sum['c624bbfcc900'].vat, sum['c624bbfcc900'].total);
    }
    if (lastOne3 != undefined) {
        makeList(lastOne3, sum['c774c815d604'].ea, sum['c774c815d604'].price, sum['c774c815d604'].supply, sum['c774c815d604'].vat, sum['c774c815d604'].total);
    }
    if (lastOne4 != undefined) {
        makeList(lastOne4, sum['c7a5c9c0c778'].ea, sum['c7a5c9c0c778'].price, sum['c7a5c9c0c778'].supply, sum['c7a5c9c0c778'].vat, sum['c7a5c9c0c778'].total);
    }
}

// Sum 객체의 값을 담은 합계 행(tr+td) 생성 함수
var makeList = (lastOne, ea, price, supply, vat, total) => {
    var parent = lastOne.parentNode.parentNode; // 각 담당자 마지막 행 매개변수로 받아 저장
        var tr = document.createElement('tr'); // tr, td 요소 생성
        var td1 = document.createElement('td');
        var td2 = document.createElement('td');
        var td3 = document.createElement('td');
        var td4 = document.createElement('td');
        var td5 = document.createElement('td');
        var td6 = document.createElement('td');
        var td7 = document.createElement('td');

        td1.innerHTML = lastOne.innerHTML.trim()+' total'; // 담당자 명을 lastOne에서 추출하여 td1에 저장

        tr.classList += 'sum_line'; // 각각의 tr, td에 css를 적용하기 위해 클래스명 정의
        td1.classList += 'val1';
        td2.classList += 'val2';
        td3.classList += 'val2';
        td4.classList += 'val2';
        td5.classList += 'val2';
        td6.classList += 'val2';
        td7.classList += 'val1';

        td1.setAttribute('colspan', '5');
        td2.innerHTML += addComma(ea); // 각각의 td에 각 담당자에 대한 판매수량, 가격, 공급가, 부가세, 합계금액의 총합을 저장
        td3.innerHTML += addComma(price);
        td4.innerHTML += addComma(supply);
        td5.innerHTML += addComma(vat);
        td6.innerHTML += addComma(total);
        td7.setAttribute('colspan', '3');
        td7.innerHTML += '-';

        tr.appendChild(td1); // 값이 저장된 td들을 tr에 저장
        tr.appendChild(td2);
        tr.appendChild(td3);
        tr.appendChild(td4);
        tr.appendChild(td5);
        tr.appendChild(td6);
        tr.appendChild(td7);

        parent.insertAdjacentElement('afterend', tr); // 최종 SUM 데이터가 담긴 행을 마지막 담당자 행 밑에 추가
        // printSum 모듈종료 (객체에 저장된 합계 값들을 화면에 프린트 종료)
}

getSum(); 
printSum();




