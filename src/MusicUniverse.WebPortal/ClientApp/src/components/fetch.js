export async function home(){
    let res;
    await fetch("api/home")
        .then(res => res.json())
        .then(
            (result) => {
                res = result;
                res.failed = false;
            },
            (error) => {
                res = error
                res.failed = true;
            });            
    
    return res;
}

export async function artists() {
    let res;
    await fetch("api/artists")
        .then(res => res.json())
        .then((result) => {
            res = result
            res.failed = false
        },
            (error) => {
            res = error
            res.failed = true
        })

    return res;
}