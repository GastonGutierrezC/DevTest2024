import { useState, useEffect } from "react";
import { getPolls } from "../Api/PollApi";

function useFetchPolls() {
    const [polls, setPolls] = useState([]); // Inicializar como array vacío
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchPolls = async () => {
            try {
                const data = await getPolls();
                // Verifica si los datos son un array
                setPolls(Array.isArray(data) ? data : []);
            } catch (error) {
                setError("Error al obtener los polls");
            } finally {
                setLoading(false);
            }
        };

        fetchPolls();
    }, []);

    return { polls, loading, error };
}

export default useFetchPolls;
