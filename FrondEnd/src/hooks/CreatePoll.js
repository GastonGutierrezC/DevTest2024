import { useState } from "react";
import { createPoll } from "../Api/PollApi";

function usePollForm() {
    const [pollName, setPollName] = useState('');
    const [options, setOptions] = useState([{ optionName: '' }]);
    const [message, setMessage] = useState('');

    const handleAddOption = () => {
        setOptions([...options, { optionName: '' }]);
    };

    const handleRemoveOption = (index) => {
        setOptions(options.filter((_, i) => i !== index));
    };

    const handleOptionChange = (index, value) => {
        const newOptions = options.map((option, i) =>
            i === index ? { ...option, optionName: value } : option
        );
        setOptions(newOptions);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const pollData = {
            pollName,
            options,
        };

        try {
            const response = await createPoll(pollData);
            if (response?.status === 200) {
                setMessage('Poll creado con éxito');
                setPollName('');
                setOptions([{ optionName: '' }]);
            } else {
                setMessage('No se pudo crear el poll');
            }
        } catch (error) {
            const errorMessage = error.response?.data?.message || 'Hubo un problema al crear el poll';
            setMessage(errorMessage);
        }
    };

    return {
        pollName,
        setPollName,
        options,
        handleAddOption,
        handleRemoveOption,
        handleOptionChange,
        message,
        handleSubmit,
    };
}

export default usePollForm;
