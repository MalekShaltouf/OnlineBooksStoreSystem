var VoteBtn = document.getElementById("VoteBtn");
var BookDetailsForm = document.getElementById("BookDetailsForm");

//VoteBtn.onclick = function () {
//    //var BDChild2Div = document.createElement("div"),
//    //    Div1 = BDChild2Div.cloneNode(),
//    //    Div2 = BDChild2Div.cloneNode(),
//    //    Div3 = BDChild2Div.cloneNode(),
//    //    Div4 = BDChild2Div.cloneNode(),
//    //    Div5 = BDChild2Div.cloneNode(),
//    //    RadioInput = document.createElement("input"),
//    //    RadioInput2 = RadioInput.cloneNode(),
//    //    RadioInput3 = RadioInput.cloneNode(),
//    //    RadioInput4 = RadioInput.cloneNode(),
//    //    RadioInput5 = RadioInput.cloneNode(),
//    //    StarImage = document.createElement("img"),
//    //    StarImage2 = StarImage.cloneNode,
//    //    StarImage3 = StarImage.cloneNode,
//    //    StarImage4 = StarImage.cloneNode,
//    //    StarImage5 = StarImage.cloneNode,
//    //    StarImage6 = StarImage.cloneNode,
//    //    StarImage7 = StarImage.cloneNode,
//    //    StarImage8 = StarImage.cloneNode,
//    //    StarImage9 = StarImage.cloneNode,
//    //    StarImage10 = StarImage.cloneNode,
//    //    StarImage11 = StarImage.cloneNode,
//    //    StarImage12 = StarImage.cloneNode,
//    //    StarImage13 = StarImage.cloneNode,
//    //    StarImage14 = StarImage.cloneNode,
//    //    StarImage15 = StarImage.cloneNode;


//    //DCChildDiv.setAttribute("class", ".BD-Child2");
    
//    //var DivsArr = [Div1, Div2, Div3, Div4, Div5],
//    //    inputArr = [RadioInput, RadioInput2, RadioInput3, RadioInput4, RadioInput5],
//    //    ImageArr = [StarImage, StarImage2, StarImage3, StarImage4, StarImage5, StarImage6, StarImage7, StarImage8, StarImage9, StarImage10, StarImage11, StarImage12, StarImage13, StarImage14, StarImage15];

//    //for (var i = 0; i < inputArr.length; i++)
//    //{
//    //    inputArr[i].setAttribute("type", "radio");
//    //    inputArr[i].setAttribute("class", "RadioBtn");
//    //    inputArr[i].setAttribute("id", "Star" + (i + 1));
//    //    inputArr[i].setAttribute("name", "Rate");
//    //    inputArr[i].setAttribute("value", (i + 1).toString());
//    //    inputArr[i].setAttribute("runat", "server");
//    //    DivsArr[i].appendChild(inputArr[i]);
//    //}
//    //for (var i = 0; i < ImageArr.length; i++)
//    //{
//    //    ImageArr[i].setAttribute("src", "../../Images/Icons/icons8-star-64.png");
//    //}
//    //DivsArr[0].appendChild(ImageArr[0]);
//    //for (var i = 1; i < 3; i++)
//    //{
//    //    DivsArr[1].appendChild(ImageArr[i]);
//    //}
//    //for (var i = 3; i < 6; i++)
//    //{
//    //    DivsArr[2].appendChild(ImageArr[i]);
//    //}
//    //for (var i = 6; i < 10; i++) {
//    //    DivsArr[3].appendChild(ImageArr[i]);
//    //}
//    //for (var i = 10; i < 15; i++) {
//    //    DivsArr[4].appendChild(ImageArr[i]);
//    //}
//    //for (var i = 0; i < DivsArr.length; i++)
//    //{
//    //    BDChild2Div.appendChild(DivsArr[i]);
//    //}

//    //BookDetailsForm.appendChild(BDChild2Div);
//    console.log("ss");
//};

console.log("ss");

console.log(document.getElementById("rr"));

function rstx() {
        var BDChild2Div = document.createElement("div"),
            Div1 = BDChild2Div.cloneNode(),
            Div2 = BDChild2Div.cloneNode(),
            Div3 = BDChild2Div.cloneNode(),
            Div4 = BDChild2Div.cloneNode(),
            Div5 = BDChild2Div.cloneNode(),
            RadioInput = document.createElement("input"),
            RadioInput2 = RadioInput.cloneNode(),
            RadioInput3 = RadioInput.cloneNode(),
            RadioInput4 = RadioInput.cloneNode(),
            RadioInput5 = RadioInput.cloneNode(),
            StarImage = document.createElement("img"),
            StarImage2 = StarImage.cloneNode,
            StarImage3 = StarImage.cloneNode,
            StarImage4 = StarImage.cloneNode,
            StarImage5 = StarImage.cloneNode,
            StarImage6 = StarImage.cloneNode,
            StarImage7 = StarImage.cloneNode,
            StarImage8 = StarImage.cloneNode,
            StarImage9 = StarImage.cloneNode,
            StarImage10 = StarImage.cloneNode,
            StarImage11 = StarImage.cloneNode,
            StarImage12 = StarImage.cloneNode,
            StarImage13 = StarImage.cloneNode,
            StarImage14 = StarImage.cloneNode,
            StarImage15 = StarImage.cloneNode;


        BDChild2Div.setAttribute("class", ".BD-Child2");

        var DivsArr = [Div1, Div2, Div3, Div4, Div5],
            InputArr = [RadioInput, RadioInput2, RadioInput3, RadioInput4, RadioInput5],
            ImageArr = [StarImage, StarImage2, StarImage3, StarImage4, StarImage5, StarImage6, StarImage7, StarImage8, StarImage9, StarImage10, StarImage11, StarImage12, StarImage13, StarImage14, StarImage15];

        for (var i = 0; i < InputArr.length; i++)
        {
            InputArr[i].setAttribute("type", "radio");
            InputArr[i].setAttribute("class", "radiobtn");
            InputArr[i].setAttribute("id", "star" + (i + 1));
            InputArr[i].setAttribute("name", "rate");
            InputArr[i].setAttribute("value", (i + 1).toString());
            InputArr[i].setAttribute("runat", "server");
            DivsArr[i].appendChild(InputArr[i]);
        }
        for (var i = 0; i < ImageArr.length; i++)
        {
            ImageArr[i].setAttribute("src", "../../images/icons/icons8-star-64.png");
        }
        DivsArr[0].appendChild(ImageArr[0]);
        for (var i = 1; i < 3; i++)
        {
            DivsArr[1].appendChild(ImageArr[i]);
        }
        for (var i = 3; i < 6; i++)
        {
            DivsArr[2].appendChild(ImageArr[i]);
        }
        for (var i = 6; i < 10; i++) {
            DivsArr[3].appendChild(ImageArr[i]);
        }
        for (var i = 10; i < 15; i++) {
            DivsArr[4].appendChild(ImageArr[i]);
        }
        for (var i = 0; i < DivsArr.length; i++)
        {
            BDChild2Div.appendChild(DivsArr[i]);
        }

        BookDetailsForm.appendChild(BDChild2Div);
    return false;
};

var BDChild2Div = document.createElement("div"),
            Div1 = BDChild2Div.cloneNode(),
            Div2 = BDChild2Div.cloneNode(),
            Div3 = BDChild2Div.cloneNode(),
            Div4 = BDChild2Div.cloneNode(),
            Div5 = BDChild2Div.cloneNode(),
            RadioInput = document.createElement("input"),
            RadioInput2 = RadioInput.cloneNode(),
            RadioInput3 = RadioInput.cloneNode(),
            RadioInput4 = RadioInput.cloneNode(),
            RadioInput5 = RadioInput.cloneNode(),
            StarImage = document.createElement("img"),
            StarImage2 = StarImage.cloneNode,
            StarImage3 = StarImage.cloneNode,
            StarImage4 = StarImage.cloneNode,
            StarImage5 = StarImage.cloneNode,
            StarImage6 = StarImage.cloneNode,
            StarImage7 = StarImage.cloneNode,
            StarImage8 = StarImage.cloneNode,
            StarImage9 = StarImage.cloneNode,
            StarImage10 = StarImage.cloneNode,
            StarImage11 = StarImage.cloneNode,
            StarImage12 = StarImage.cloneNode,
            StarImage13 = StarImage.cloneNode,
            StarImage14 = StarImage.cloneNode;


BDChild2Div.setAttribute("class", ".BD-Child2");

var DivsArr = [Div1, Div2, Div3, Div4, Div5],
    InputArr = [RadioInput, RadioInput2, RadioInput3, RadioInput4, RadioInput5];
    var ImageArr = [StarImage, StarImage2, StarImage3, StarImage4, StarImage5, StarImage6, StarImage7, StarImage8, StarImage9, StarImage10, StarImage11, StarImage12, StarImage13, StarImage14]

for (var i = 0; i < InputArr.length; i++) {
    InputArr[i].setAttribute("type", "radio");
    InputArr[i].setAttribute("class", "radiobtn");
    InputArr[i].setAttribute("id", "star" + (i + 1));
    InputArr[i].setAttribute("name", "rate");
    InputArr[i].setAttribute("value", (i + 1).toString());
    InputArr[i].setAttribute("runat", "server");
    DivsArr[i].appendChild(InputArr[i]);
}
//for (var j = 0; j < ImageArr.length; j++) {
//    //ImageArr[j].setAttribute("src", "../../images/icons/icons8-star-64.png");
//}

ImageArr[0].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[1].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[2].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[3].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[4].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[5].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[6].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[6].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[8].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[9].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[10].setAttribute("src", "../../images/icons/icons8-star-64.png");
ImageArr[11].setAttribute("src", "../../images/icons/icons8-star-64.png");

for (var j = 0; j < ImageArr.length; j++) {
    console.log(ImageArr[j]);
}

//DivsArr[0].appendChild(ImageArr[0]);
//for (var i = 1; i < 3; i++) {
//    DivsArr[1].appendChild(ImageArr[i]);
//}
//for (var i = 3; i < 6; i++) {
//    DivsArr[2].appendChild(ImageArr[i]);
//}
//for (var i = 6; i < 10; i++) {
//    DivsArr[3].appendChild(ImageArr[i]);
//}
//for (var i = 10; i < 15; i++) {
//    DivsArr[4].appendChild(ImageArr[i]);
//}
//for (var i = 0; i < DivsArr.length; i++) {
//    BDChild2Div.appendChild(DivsArr[i]);
//}

BookDetailsForm.appendChild(BDChild2Div);