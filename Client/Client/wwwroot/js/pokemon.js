// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//let getCol = document.querySelector(".col-grid1");
//let click = document.getElementById("clickMe");
//click.addEventListener("click", () => {

//    if (getCol.classList.contains("bg-success")) {
//        getCol.classList.remove("bg-success")
//    } else {
//        getCol.classList.add("bg-success")
//    }
//})

//getCol.addEventListener("mouseover", () => {
//    getCol.classList.toggle("bg-secondary")
//})
//getCol.addEventListener("mouseleave", () => {
//    getCol.classList.toggle("bg-secondary")
//})


//let getCol2 = document.querySelector(".col-grid2");
//getCol2.addEventListener("mouseover", () => {
//    getCol2.classList.toggle("bg-danger")
//})
//getCol2.addEventListener("mouseleave", () => {
//    getCol2.classList.toggle("bg-danger")
//})

//let getCol3 = document.querySelector(".col-grid3");
//getCol3.addEventListener("mouseover", () => {
//    getCol3.classList.toggle("bg-warning")
//})
//getCol3.addEventListener("mouseleave", () => {
//    getCol3.classList.toggle("bg-warning")
//})

////Array

//console.log("test")

////array of object
//const animals = [
//    { name: "dory", species: "fish", class: { name: "vertebrata" } },
//    { name: "tom", species: "cat", class: { name: "mamalia" } },
//    { name: "nemo", species: "fish", class: { name: "vertebrata" } },
//    { name: "umar", species: "cat", class: { name: "mamalia" } },
//    { name: "gary", species: "fish", class: { name: "human" } },
//]

//console.log("animalas")


//const onlyCat = new Array();

//// Fungsi 1
//for (var i = 0; i < animals.length ; i++) {

//    if (animals[i]["species"] == "cat"){
//        onlyCat.push(animals[i]);
//        animals.splice(i, 1)
//    }
//}
//console.log(onlyCat);
//console.log(animals);


////Fungsi 2
//for (var i = 0; i < animals.length; i++) {

//    if (animals[i]["class"]["name"] != "non-mamalia") {
//        animals[i]["class"]["name"] = "non-mamalia"
//    }
//}
//console.log(animals);

//Fungsi 1 dan 2
//for (var i = 0; i < animals.length; i++) {

//    if (animals[i]["species"] == "cat") {
//        onlyCat.push(animals[i]);
//        animals.splice(i, 1)
//    }
//    if (animals[i]["class"]["name"] != "non-mamalia") {
//        animals[i]["class"]["name"] = "non-mamalia"
//    }
//}
//console.log(onlyCat);
//console.log(animals);
//asynchronous javascript
//asynchronous javascript
//asynchronous javascript
$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon"
}).done((result) => {
    let temp = "";
    $.each(result.results, (key, val) => {
        temp += `
                <tr>
                    <td>${key + 1}</td>
                    <td>${val.name}</td>
                    <td><button onclick="detailSW('${val.url}')" data-bs-toggle="modal" data-bs-target="#modalSW" class="btn btn-primary">Detail</button></td>
                </tr>
            `;
    })
    $("#tbodySW").html(temp);
});

function detailSW(stringURL) {

    $.ajax({

        url: stringURL,
        success: (result) => {
            let temp2 = "";
            let typePoke = "";
            let imagesPoke = "";
            let progressPoke = "";
            let abilitiesPoke = "";
            let aboutsPoke = "";
            let progressPoke1 = ProgressColor(result.stats['0']['base_stat']);
            let progressPoke2 = ProgressColor(result.stats['1']['base_stat']);
            let progressPoke3 = ProgressColor(result.stats['2']['base_stat']);
            let progressPoke4 = ProgressColor(result.stats['3']['base_stat']);
            let progressPoke5 = ProgressColor(result.stats['4']['base_stat']);
            let progressPoke6 = ProgressColor(result.stats['5']['base_stat']);

            imagesPoke = ` <img src="${result.sprites.other.dream_world['front_default']}" class="card-img-top" alt="gambar" id="imagesPoke">`;


            $.each(result.abilities, (key, val) => {

                abilitiesPoke += `
                <span class="border border-dark abilities" >${val.ability['name']}</span>
            `;
            })

            $.each(result.types, (key, val) => {

                let typeColor = getTypeColor(val.type['name']);
                typePoke += `
                <span class = "badge rounded-pill" style = "background-color: ${typeColor}">${val.type['name']}</span>
            `;
            })

            aboutsPoke = `
            <table class="table table-borderless">
              <tbody>
                <tr>
                  <td>Species</td>
                  <td>${typePoke}</td>
                </tr>
                <tr>
                  <td>Height</td>
                  <td>${result.height}cm</td>
                </tr>
                <tr>
                  <td>Weight</td>
                  <td>${result.weight}kg</td>
                </tr>
                <tr>
                  <td>Abilities</td>
                  <td>${abilitiesPoke}</td>
                </tr>
              </tbody>
            </table>
            `;

            namePoke = `
                   <h5 class="card-title" > ${result.name}</h5>
            `;
            progressPoke = `
                            <table class="table table-borderless">
                              <tbody>
                                <tr>
                                  <td class="col-md-4">HP</td>
                                  <td>
                                    <div class="progress">
                                        <div class="progress-bar " role="progressbar" style="width: ${result.stats['0']['base_stat']}%; background-color : ${progressPoke1};" aria-valuenow="${result.stats['0']['base_stat']}" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                  </td>
                                </tr>
                                <tr>
                                  <td>Attack</td>
                                  <td>
                                    <div class="progress">
                                      <div class="progress-bar " role="progressbar" style="width: ${result.stats['1']['base_stat']}%; background-color : ${progressPoke2};" aria-valuenow="${result.stats['1']['base_stat']}" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                  </td>
                                </tr>
                                <tr>
                                  <td>Defense</td>
                                  <td>
                                    <div class="progress">
                                      <div class="progress-bar " role="progressbar" style="width: ${result.stats['2']['base_stat']}%; background-color : ${progressPoke3};" aria-valuenow="${result.stats['2']['base_stat']}" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                  </td>
                                </tr>
                                <tr>
                                  <td>Special Attack</td>
                                  <td>
                                     <div class="progress">
                                        <div class="progress-bar " role="progressbar" style="width: ${result.stats['3']['base_stat']}%; background-color : ${progressPoke4};" aria-valuenow="${result.stats['3']['base_stat']}" aria-valuemin="0" aria-valuemax="100"></div>
                                     </div>
                                  </td>
                                </tr>
                                <tr>
                                  <td>Special Defense</td>
                                  <td>
                                    <div class="progress">
                                      <div class="progress-bar " role="progressbar" style="width: ${result.stats['4']['base_stat']}%; background-color : ${progressPoke5};" aria-valuenow="${result.stats['4']['base_stat']}" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                  </td>
                                </tr>
                                <tr>
                                  <td>Speed</td>
                                  <td>
                                    <div class="progress">
                                      <div class="progress-bar " role="progressbar" style="width: ${result.stats['5']['base_stat']}%; background-color : ${progressPoke6};" aria-valuenow="${result.stats['5']['base_stat']}" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                  </td>
                                </tr>
                              </tbody>
                            </table>
            `;
            $('.col-image').html(imagesPoke);
            $('.col-name').html(namePoke);
            $('.progressCard').html(progressPoke);
            $('.modal-title').html(namePoke);
            $('.abilitiesCard').html(abilitiesPoke);
            $('.aboutsCard').html(aboutsPoke);

        }

    });
}
function getTypeColor(typeName) {
    let typeColor = "";
    switch (typeName) {
        case "water":
            typeColor = "#B0E0E6";
            break;

        case "fire":
            typeColor = "#FF8C00";
            break;

        case "grass":
            typeColor = "#228B22";
            break;

        case "poison":
            typeColor = "#4B0082";
            break;

        case "flying":
            typeColor = "#778899";
            break;

        case "bug":
            typeColor = "#008080";
            break;
        case "normal":
            typeColor = "#696969"
            break;


    }
    return typeColor;
}
function ProgressColor(progress) {

    let color = "";
        if (progress >= "80") {
            color = "#ff0000";
        } else if (progress >= "50" && progress < "80") {
            color = "#ffd800";
        } else {
            color = "#00ff21";
        }
    return color;
};



