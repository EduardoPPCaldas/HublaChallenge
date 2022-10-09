import axios from "axios";

export async function getSales(){
    await axios.get("http://localhost:5015/api/sale")
        .then(res => {
            console.log(res);
        })
} 