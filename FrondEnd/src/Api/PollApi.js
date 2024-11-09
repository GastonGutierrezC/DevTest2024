import axios from "axios";


export const createPoll = async (poll) => {
    try{
        const response = await axios.post('http://localhost:5258/Poll', poll)
        return response;
    } catch (error){
        console.error('Error al crear el poll : ', error);
        return { status: error.response}
    }
}