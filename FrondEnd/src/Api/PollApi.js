import axios from "axios";


export const createPoll = async (poll) => {
    try{
        const response = await axios.post('http://localhost:5258/Poll', poll)
        return response;
    } catch (error){
        console.error('Error al crear el poll : ', error);
        return { status: error.response ? error.response.status: 500 ,error};
    }
};

export const getPolls = async () => {
    try{
        const response = await axios.get('http://localhost:5258/Poll')
        return response;
    } catch (error){
        console.error('Error al tener el poll : ', error);
        return { status: error.response ? error.response.status: 500 ,error};
    }
}