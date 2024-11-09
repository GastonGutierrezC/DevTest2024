import React from 'react';
import { TextField, Button, Box, Container, Typography, IconButton, Alert } from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import RemoveIcon from '@mui/icons-material/Remove';
import usePollForm from "../hooks/CreatePoll";

export default function PollForm() {
    const {
        pollName,
        setPollName,
        options,
        handleAddOption,
        handleRemoveOption,
        handleOptionChange,
        message,
        handleSubmit,
    } = usePollForm();

    return (
        <Container maxWidth="sm">
            <Box
                component="form"
                noValidate
                autoComplete="off"
                onSubmit={handleSubmit}
                sx={{
                    display: 'flex',
                    flexDirection: "column",
                    alignItems: "center",
                    '& .MuiTextField-root': { m: 1, width: '100%' },
                    '& button': { m: 1 }
                }}
            >
                <Typography variant="h6" gutterBottom>
                    Crear Poll
                </Typography>

                <TextField
                    label="Nombre del Poll"
                    value={pollName}
                    onChange={(e) => setPollName(e.target.value)}
                    required
                />

                <Typography variant="subtitle1" gutterBottom>
                    Opciones
                </Typography>

                {options.map((option, index) => (
                    <Box key={index} sx={{ display: 'flex', alignItems: 'center', width: '100%' }}>
                        <TextField
                            label={`Opción ${index + 1}`}
                            value={option.optionName}
                            onChange={(e) => handleOptionChange(index, e.target.value)}
                            required
                            fullWidth
                        />
                        <IconButton
                            color="error"
                            onClick={() => handleRemoveOption(index)}
                            disabled={options.length === 1}
                        >
                            <RemoveIcon />
                        </IconButton>
                    </Box>
                ))}

                <Button
                    variant="outlined"
                    color="primary"
                    onClick={handleAddOption}
                    startIcon={<AddIcon />}
                >
                    Agregar Opción
                </Button>

                <Button
                    type="submit"
                    variant="contained"
                    color="primary"
                    sx={{ mt: 2 }}
                >
                    Crear Poll
                </Button>

                {message && (
                    <Alert severity={message.includes('éxito') ? 'success' : 'error'} sx={{ mt: 2, width: '100%' }}>
                        {message}
                    </Alert>
                )}
            </Box>
        </Container>
    );
}
