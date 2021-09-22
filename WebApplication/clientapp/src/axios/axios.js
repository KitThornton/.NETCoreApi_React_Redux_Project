import axios from 'axios';

const instance = axios.create({
    baseURL: 'https://localhost:5001',
    headers: {
        // headerType: 'example header type'
        "Accept":"application/json"
        // "Access-Control-Allow-Origin": "http://localhost:3000/owner-list"
    }
});

export default instance;