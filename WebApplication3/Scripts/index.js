url = "List";

function Get() {
    
    let html = document.getElementById('tbData');
    fetch(url)
        .then(function (resp) {
            console.log(resp.body)
            return resp.text()
            
        }).then((data) => {
            html.innerHTML = data
            /*for (let s in data) {
                console.log("aquii", data)
                console.log(s)
                html.innerHTML =+ `
                    <tr>
                        <th scope="row">1</th>
                        <td>${s.Name}</td>
                        <td>${s.Description}</td>
                        <td>${s.State}</td>
                    </tr>
                `
            }*/
        })
}

Get()