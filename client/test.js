import http from 'k6/http';
import { sleep } from 'k6';

export let options = {
    vus: 100, // Virtual users
    iterations: 100,
    //duration: '1s', // Run for 1 second
};

const counter = 1;
export default function () {
    // Calculate delay to ensure all requests are sent in the last second
    // const delay = __VU * 0.01; // A small increment for each VU to stagger them a bit

    // Ensure that requests are sent during the last 1 second of the test
    // sleep(1 - delay); // Sleep for the calculated delay to send request in the last 1s

    const requestTimestamp = new Date().toISOString();
    // Log the timestamp
    console.log(`Request sent at: ${requestTimestamp}`);
    
    const bidName = `Test Bid VU${__VU}-Iter${__ITER}`; // Unique for each VU and iteration
    const randomQuantity = Math.floor(Math.random() * 100) + 1;
    
    http.post('http://localhost:5109/api/buyerauctions/01951806-fe49-72bb-b9fe-3aca8b9c19a0/bids', JSON.stringify(
	{
      "name": bidName,
      "quantity": randomQuantity,
      "unit": "m"
}), 
{
    headers: { 'Content-Type': 'application/json' },
    });
}
