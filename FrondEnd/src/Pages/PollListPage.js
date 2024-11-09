import React from 'react';
import { Container, Typography, List, ListItem, ListItemText, CircularProgress, Alert, Box } from '@mui/material';
import useFetchPolls from "../hooks/useFetchPolls";

function PollListPage() {
    const { polls, loading, error } = useFetchPolls();

    return (
        <Container maxWidth="sm">
            <Typography variant="h4" gutterBottom>
                Lista de Polls
            </Typography>

            {loading && (
                <Box display="flex" justifyContent="center" mt={2}>
                    <CircularProgress />
                </Box>
            )}

            {error && <Alert severity="error" sx={{ mt: 2 }}>{error}</Alert>}

            {!loading && !error && polls.length === 0 && (
                <Alert severity="info" sx={{ mt: 2 }}>No hay polls disponibles</Alert>
            )}

            <List sx={{ mt: 2 }}>
                {polls.map((poll) => (
                    <ListItem key={poll.id} divider>
                        <ListItemText
                            primary={poll.pollName}
                            secondary={poll.options.map(option => option.optionName).join(", ")}
                        />
                    </ListItem>
                ))}
            </List>
        </Container>
    );
}

export default PollListPage;
